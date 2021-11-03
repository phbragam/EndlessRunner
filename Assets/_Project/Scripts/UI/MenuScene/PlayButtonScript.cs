using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public sealed class PlayButtonScript : MonoBehaviour
{
    [SerializeField] GameObject _loadingPanel;

    private Button _button;

    private void Initialize()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(LoadNext);
    }

    private void Awake()
    {
        Initialize();
    }

    private void LoadNext()
    {
        AudioManagerScript.Instance.Play("Botao");
        _loadingPanel.SetActive(true);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
