using System;
using UnityEngine;

public sealed class PlayerDieScript : MonoBehaviour
{
    public static event Action OnPlayerDied;

    private void OnEnable()
    {
        OnPlayerDied += PlayDeathSound;
    }

    private void OnDisable()
    {
        OnPlayerDied -= PlayDeathSound;
    }

    private void OnCollisionEnter(Collision collision)
    {
        InvokeDeathEventOnCollision(collision);
    }

    private void InvokeDeathEventOnCollision(Collision collision)
    {

        if (collision.gameObject.GetComponent<ObstacleReference>())
        {
            OnPlayerDied?.Invoke();
        }

    }

    private void PlayDeathSound()
    {
        AudioManagerScript.Instance.Play("Morte");
    }
}
