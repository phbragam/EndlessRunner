using UnityEngine;

public sealed class CoinSpin : MonoBehaviour
{
    [SerializeField] private float _turnSpeed = 90f;

    private void Update()
    {
        transform.Rotate(0, 0, _turnSpeed * Time.deltaTime);
    }
}
