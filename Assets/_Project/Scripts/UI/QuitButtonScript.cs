using UnityEngine;
using UnityEngine.UI;

public sealed class QuitButtonScript : MonoBehaviour
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
        AudioManagerScript.Instance.Play("Botao");
        Application.Quit();
    }

}
