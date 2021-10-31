using UnityEngine;

public sealed class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private Vector3 _offset;

    public void Initialize()
    {
        Start();
    }

    private void Start()
    {
        PlaceAndSetUpOffset();
    }

    private void LateUpdate()
    {
        FollowPlayer();
    }

    private void PlaceAndSetUpOffset()
    {
        _player = FindObjectOfType<PlayerReference>().gameObject.transform;
        _offset = transform.position - _player.position;
    } 

    private void FollowPlayer()
    {
        Vector3 targetPos = _player.position + _offset;
        targetPos.x = 0;
        transform.position = targetPos;
    }
}
