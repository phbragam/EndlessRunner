using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class SceneGameManager : MonoBehaviour
{
    public void Initialize()
    {
        
    }

    private void Awake()
    {
        Initialize();
    }

    //private void OnEnable()
    //{
    //    PlayerDieScript.OnPlayerDied += DelayedReloadScene;
    //}

    //private void OnDisable()
    //{
    //    PlayerDieScript.OnPlayerDied -= DelayedReloadScene;
    //}

    //private void DelayedReloadScene()
    //{
    //    //Invoke("Load", 5f);
    //}

    //private void Load()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}
}
