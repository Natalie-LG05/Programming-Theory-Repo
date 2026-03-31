using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] protected int pointValue = 1;
    [SerializeField] protected int pointCost = 0;

    protected ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
    }

    /// <summary>
    /// Called when this node is clicked
    /// </summary>
    protected virtual void OnClick()
    {
        scoreManager.score += pointValue;
    }

    /// <summary>
    /// Called when this node is unlocked
    /// </summary>
    protected virtual void OnActivate()
    {
        gameObject.SetActive(true);
    }
}
