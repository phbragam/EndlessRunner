using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class SceneGameManager : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerDieScript.OnPlayerDied += DelayedReloadScene;
    }

    private void OnDisable()
    {
        PlayerDieScript.OnPlayerDied -= DelayedReloadScene;
    }

    private void DelayedReloadScene()
    {
        Invoke("Load", 2f);
    }

    void Load()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}