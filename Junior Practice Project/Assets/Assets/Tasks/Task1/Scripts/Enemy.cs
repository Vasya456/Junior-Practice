using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private Vector3 _direction;

    public void SetDirection(Vector3 direction)
    {
        _direction = direction.normalized;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }
}
