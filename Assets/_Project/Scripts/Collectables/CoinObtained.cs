using UnityEngine;

public sealed class CoinObtained : CollectableObtained
{
    public static CollectableObtainedHandler OnCoinObtainedByPlayer;
    //public static event Action OnCoinObtainedByPlayer;

    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<ObstacleReference>())
        {
            gameObject.SetActive(false);
            return;
        }

        if (!other.gameObject.GetComponent<PlayerReference>())
        {
            return;
        }

        OnCoinObtainedByPlayer?.Invoke();

        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        OnCoinObtainedByPlayer += PlayCoinSound;
    }

    private void OnDisable()
    {
        OnCoinObtainedByPlayer -= PlayCoinSound;
    }

    private void PlayCoinSound()
    {
        AudioManagerScript.Instance.Play("Coin");
    }
}
