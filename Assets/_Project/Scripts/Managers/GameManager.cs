using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager inst;

    private void Awake()
    {
        inst = this;
    }
    // criar outro manager para salvar o dado do leaderboard
}
