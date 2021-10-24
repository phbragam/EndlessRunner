using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;

    public float speed = 5f;
    [SerializeField] public Rigidbody rb;

    public float speedIncreasePerPoint = .1f;


    private void FixedUpdate()
    {
        if (!alive) return;

        ForwardMove();
    }

    private void Update()
    {
        if (transform.position.y <= -5)
        {
            Die();
        }
    }

    private void ForwardMove()
    {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove);
    }

    public void Die()
    {
        alive = false;

        Invoke("ReloadScene", 1f);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
