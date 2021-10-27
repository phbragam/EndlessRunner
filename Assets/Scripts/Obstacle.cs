using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerDieScript playerDieScript;
    PrototypePlayerInputActions prototypePlayerInputActions;

    // Start is called before the first frame update
    void Start()
    {
        playerDieScript = FindObjectOfType<PlayerDieScript>();
        prototypePlayerInputActions = FindObjectOfType<PlayerJump>().prototypePlayerInputActions;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerReference>())
        {
            prototypePlayerInputActions.Player.Disable();
            playerDieScript.Die();
        }
    }
}
