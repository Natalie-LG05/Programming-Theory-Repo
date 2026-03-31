using UnityEngine;

/// <summary>
/// A node that doubles the score when clicked, but deactivates and increases in cost linearly when used
/// </summary>
public class DoubleNode : Node
{
    [SerializeField] protected int pointValueIncrease = 50;

    protected override void Awake()
    {
        base.Awake();
        SetValue("x2");
    }

    protected override void OnClick()
    {
        scoreManager.score *= 2; // double the score
        OnDeactivate();
    }

    protected override void OnDeactivate()
    {
        base.OnDeactivate();
        SetCost(pointCost + pointValueIncrease); // increase the cost of this node by 5x every time it is used
    }
}
