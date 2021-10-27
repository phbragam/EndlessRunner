using UnityEngine;
using UnityEngine.UI;

public sealed class ScoreScript : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    private int _score;

    void Start()
    {
        _scoreText = GetComponent<Text>();
    }

    private void OnEnable()
    {
        CoinObtained.OnCoinObtainedByPlayer += UpdateScore;
    }

    private void OnDisable()
    {
        CoinObtained.OnCoinObtainedByPlayer -= UpdateScore;
    }

    private void UpdateScore()
    {
        _score++;
        _scoreText.text = "SCORE: " + _score;
    }
}
