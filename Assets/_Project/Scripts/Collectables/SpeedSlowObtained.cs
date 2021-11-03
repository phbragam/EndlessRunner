using UnityEngine;

public sealed class SpeedSlowObtained : CollectableObtained
{
    public static CollectableObtainedHandler OnSpeedSlowObtainedByPlayer;

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

    private void OnEnable()
    {
        OnSpeedSlowObtainedByPlayer += PlaySpeedSlowSound;
    }

    private void OnDisable()
    {
        OnSpeedSlowObtainedByPlayer -= PlaySpeedSlowSound;
    }

    private void PlaySpeedSlowSound()
    {
        AudioManagerScript.Instance.Play("SpeedSlow");
    }
}
