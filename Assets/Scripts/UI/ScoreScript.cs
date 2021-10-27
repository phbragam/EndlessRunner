using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    int score;
    [SerializeField] Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
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
        score++;
        scoreText.text = "SCORE: " + score;
    }
}
