using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    /* ideally I would instead use a normal private score and have a public
    AddScore() method, but I am using a public property with a private backing
    field instead for the purposes of using encapsulation in this project */
    [SerializeField] private int _score;
    public int score 
    {
        get { return _score; }
        set { UpdateScore(value); }
    }

    private void Start()
    {
        UpdateScore(0);
    }

    private void UpdateScore(int value)
    {
        // prevent score from going below 0
        _score = value >= 0 ? value : 0;
        scoreText.text = $"Score: {this.score}";
    }
}
