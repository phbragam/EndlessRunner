using UnityEngine;

public class JumpBoostObtained : CollectableObtained
{
    public static CollectableObtainedHandler OnJumpBoostObtainedByPlayer;
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

        OnJumpBoostObtainedByPlayer?.Invoke();

        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        OnJumpBoostObtainedByPlayer += PlayJumpBoostSound;
    }

    private void OnDisable()
    {
        OnJumpBoostObtainedByPlayer -= PlayJumpBoostSound;
    }

    private void PlayJumpBoostSound()
    {
        AudioManagerScript.Instance.Play("JumpBoost");
    }
}
