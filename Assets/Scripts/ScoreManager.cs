using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    private int _score;
    public int score
    {
        get { return score; }
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
