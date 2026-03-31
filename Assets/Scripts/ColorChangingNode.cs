using UnityEngine;

/// <summary>
/// This is a type of node that functions similarly to the basic node, 
/// except that it starts with a random color and changes colors randomly 
/// whenever it is clicked while active
/// </summary>
public class ColorChangingNode : Node // INHERITANCE
{
    [SerializeField] protected Color[] colors;

    protected SpriteRenderer spriteRenderer;

    protected override void Awake()
    {
        base.Awake();
        spriteRenderer = GetComponent<SpriteRenderer>();

        //Debug.Log("Color");
    }

    private void Start()
    {
        ChangeColor();
    }

    protected override void OnClick() // POLYMORPHISM
    {
        base.OnClick();
        ChangeColor();
    }

    private Color RandomColor()
    {
        int randomIndex = Random.Range(0, colors.Length);
        return colors[randomIndex];
    }

    private void ChangeColor() // ABSTRACTION
    {
        spriteRenderer.color = RandomColor();
        SetAlpha(isActivated ? 255.0f : transparentAVal);
    }
}
