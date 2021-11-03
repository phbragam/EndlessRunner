using UnityEngine;

public sealed class PlayRoundaboutOnAwake : MonoBehaviour
{
    public void Initialize()
    {
        AudioManagerScript.Instance.Play("Roundabout");
    }

    private void Awake()
    {
        Initialize();
    }
}
