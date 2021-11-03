using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitButtonScript : MonoBehaviour
{
    private Button _button;

    private void Initialize()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Quit);
    }

    private void Awake()
    {
        Initialize();
    }

    private void Quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }

}
