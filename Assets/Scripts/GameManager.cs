using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int score;
    public static GameManager inst;

    // mover texto pra ui que vai escutar o evento de mudança na pontuação
    [SerializeField] Text scoreText;

    [SerializeField] PlayerMovement playerMovement;
    
    public void IncrementScore()
    {
        score++;
        scoreText.text = "SCORE: " + score;
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }

    private void Awake()
    {
        inst = this;
    }

    // cena vai ser recarregada na morte aqui
    // manager vai escutar a morte do jogador e recarregar a cena
    // criar outro manager para salvar o dado do leaderboard

}
