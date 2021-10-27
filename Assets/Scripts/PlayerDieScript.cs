using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDieScript : MonoBehaviour
{
    // adicionar propriedade para esse bool
    public bool alive = true;

    // fazer esse script escutar sempre que um jogador morre

    public void Die()
    {
        alive = false;

        Invoke("ReloadScene", 1f);
    }

    private void Update()
    {
        if (transform.position.y <= -5)
        {
            Die();
        }
    }

    // mover esse metodo para controlador escutar quando o jogador morre
    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
