using UnityEngine;

public class SpeedSlowObtained : CollectableObtained
{
    public static CollectableObtainedHandler OnSpeedSlowObtainedByPlayer;
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

        OnSpeedSlowObtainedByPlayer?.Invoke();

        gameObject.SetActive(false);
    }
}
