using UnityEngine;
using UnityEngine.UI;

public sealed class ScoreScript : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    [SerializeField] private GameObject _highScorePanel;
    [SerializeField] private Text _gameOverScoreText;
    [SerializeField] private Text _highScoreText;

    [SerializeField] private int _actualScore;
    [SerializeField] private IntValue _highScore;

    public void Initialize()
    {

    }

    private void Awake()
    {
        _highScorePanel.SetActive(false);
    }

    private void Start()
    {

    }

    private void OnEnable()
    {
        CoinObtained.OnCoinObtainedByPlayer += UpdateScore;
        PlayerDieScript.OnPlayerDied += UpdateHighScore;
        PlayerDieScript.OnPlayerDied += DelayedActivateAndSetupHighScoreScreen;
    }

    private void OnDisable()
    {
        CoinObtained.OnCoinObtainedByPlayer -= UpdateScore;
        PlayerDieScript.OnPlayerDied -= UpdateHighScore;
        PlayerDieScript.OnPlayerDied -= DelayedActivateAndSetupHighScoreScreen;
    }

    private void UpdateScore()
    {
        _actualScore ++;
        _scoreText.text = "SCORE: " + _actualScore;
    }

    private void UpdateHighScore()
    {

        if (_actualScore > _highScore.intValue)
        {
            _highScore.intValue = _actualScore;
        }
    }

    private void DelayedActivateAndSetupHighScoreScreen()
    {
        Invoke("ActivateAndSetupHighScoreScreen", 1f);
    }

    private void ActivateAndSetupHighScoreScreen()
    {
        _highScorePanel.SetActive(true);
        _gameOverScoreText.text = "YOUR SCORE: " + _actualScore;
        _highScoreText.text = "HIGH SCORE: " + _highScore.intValue;
    }
}
