using UnityEngine;
using UnityEngine.UI;

public sealed class ScoreScript : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private IntValue _actualScoreData;

    public void Initialize()
    {

    }

    private void Start()
    {
        _scoreText = GetComponent<Text>();
    }

    private void OnEnable()
    {
        CoinObtained.OnCoinObtainedByPlayer += UpdateScore;
        PlayerDieScript.OnPlayerDied += ResetScore;
    }

    private void OnDisable()
    {
        CoinObtained.OnCoinObtainedByPlayer -= UpdateScore;
        PlayerDieScript.OnPlayerDied -= ResetScore;
    }

    private void UpdateScore()
    {
        _actualScoreData.intValue++;
        _scoreText.text = "SCORE: " + _actualScoreData.intValue;
    }

    private void ResetScore()
    {
        _actualScoreData.intValue = _actualScoreData.defaultIntValue;
    }
}
