using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerMovement playerMovement;
    PrototypePlayerInputActions prototypePlayerInputActions;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        prototypePlayerInputActions = FindObjectOfType<PlayerInputHandler>().prototypePlayerInputActions;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerReference>())
        {
            prototypePlayerInputActions.Player.Disable();
            playerMovement.Die();
        }
    }
}
