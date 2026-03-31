using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Base node class, may be used directly or inherited from to create a node with different behavior
/// </summary>
public class Node : MonoBehaviour, IPointerDownHandler // Implement IPointerDownHandler in order to use OnPointerDown to detect when this object is clicked
{
    [SerializeField] protected int pointValue = 1;
    [SerializeField] protected int pointCost = 0;

    [SerializeField] protected float transparentAVal = 20.0f;

    [SerializeField] protected bool isActivated;

    protected ScoreManager scoreManager;

    protected TextMeshProUGUI valueText;
    protected TextMeshProUGUI costText;

    protected virtual void Awake()
    {
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();

        valueText = transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        costText = transform.GetChild(0).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();

        SetValue(pointValue); // display the point value of this node
        SetCost(pointCost); // display the cost of buying this node

        // if the node starts deactivated, make it transparent
        if (!isActivated)
        {
            SetAlpha(transparentAVal);
        }

        //Debug.Log("Base");
    }

    protected virtual void Update()
    {
        // If the node is not already active and it's point cost has been reached, call it's OnActivate method to activate it
        if (!gameObject.activeSelf && scoreManager.score >= pointCost)
        {
            OnActivate();
        }
        else if (gameObject.activeSelf && scoreManager.score < pointCost)
        {

        }
    }

    // Called when this object is clicked, requires a collider on this object and that the camera has a Physics 2D Raycaster component
    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log($"{gameObject.name} was clicked");

        // if the node is active, perform it's click funtionality, otherwise buy it if the user has enough points
        if (isActivated)
        {
            OnClick();
            //Debug.Log($"{gameObject.name} was clicked while active");
        }
        else if (scoreManager.score >= pointCost)
        {
            scoreManager.score -= pointCost;
            OnActivate();
            //Debug.Log($"{gameObject.name} was bought");
        }
    }

    /// <summary>
    /// Set the alpha of the node's color to a new value
    /// </summary>
    /// <param name="value"></param>
    protected void SetAlpha(float value)
    {
        // set the alpha of the node's color to a new value
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color newColor = spriteRenderer.color;
        newColor.a = value / 255; // convert the a value from a value between 0-255 to a value between 0-1
        spriteRenderer.color = newColor;
    }

    protected void SetCost(int value)
    {
        pointCost = value;
        costText.text = "" + pointCost;
    }

    protected void SetValue(int value)
    {
        pointValue = value;
        valueText.text = "" + value;
    }

    protected void SetValue(string value)
    {
        valueText.text = value;
    }

    /// <summary>
    /// Called when this node is clicked
    /// </summary>
    protected virtual void OnClick()
    {
        // Default node simply adds its ponit value to the score
        scoreManager.score += pointValue;
    }

    /// <summary>
    /// Called when this node is unlocked/activated
    /// </summary>
    protected virtual void OnActivate()
    {
        // Make the node opaque and active and clickable
        isActivated = true;
        SetAlpha(255.0f);
    }

    /// <summary>
    /// Called when this node is deactivated
    /// </summary>
    protected virtual void OnDeactivate()
    {
        // Make the node transparent and inactive
        isActivated = false;
        SetAlpha(transparentAVal);
    }
}
