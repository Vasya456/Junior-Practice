using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position + Vector3.forward * _speed;
    }

    private void Update()
    {
        _targetPosition = transform.position + transform.forward * _speed;
        transform.LookAt(_targetPosition);
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}
