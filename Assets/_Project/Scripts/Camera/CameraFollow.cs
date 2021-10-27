using UnityEngine;

public sealed class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerReference>().gameObject.transform;
        _offset = transform.position - _player.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = _player.position + _offset;
        targetPos.x = 0;
        transform.position = targetPos;
    }
}
