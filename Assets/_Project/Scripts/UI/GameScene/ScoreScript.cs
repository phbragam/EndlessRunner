using System;
using UnityEngine;
using UnityEngine.UI;

public sealed class ScoreScript : MonoBehaviour
{
    public static event Action OnUpdateHighScore;

    [SerializeField] private Text _scoreText;

    [SerializeField] private GameObject _highScorePanel;
    [SerializeField] private Text _gameOverScoreText;
    [SerializeField] private Text _highScoreText;

    [SerializeField] private int _actualScore;
    [SerializeField] private IntValue _highScore;

    public void Initialize()
    {
        _highScorePanel.SetActive(false);
    }

    private void Awake()
    {
        Initialize();
    }

    private void OnEnable()
    {
        SubscribeInEvents();
    }

    private void OnDisable()
    {
        UnsubscribeInEvents();
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
            OnUpdateHighScore?.Invoke();
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

    private void SubscribeInEvents()
    {
        CoinObtained.OnCoinObtainedByPlayer += UpdateScore;
        PlayerDieScript.OnPlayerDied += UpdateHighScore;
        PlayerDieScript.OnPlayerDied += DelayedActivateAndSetupHighScoreScreen;
    }

    private void UnsubscribeInEvents()
    {
        CoinObtained.OnCoinObtainedByPlayer -= UpdateScore;
        PlayerDieScript.OnPlayerDied -= UpdateHighScore;
        PlayerDieScript.OnPlayerDied -= DelayedActivateAndSetupHighScoreScreen;
    }
}
