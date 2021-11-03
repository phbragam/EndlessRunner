using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public sealed class RetryButtonScript : MonoBehaviour
{
    private Button _button;

    private void Initialize()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ReLoad);
    }

    private void Awake()
    {
        Initialize();
    }

    private void ReLoad()
    {
        AudioManagerScript.Instance.Play("Botao");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
