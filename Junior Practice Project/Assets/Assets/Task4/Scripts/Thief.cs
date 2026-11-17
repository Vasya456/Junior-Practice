using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _target;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_target == null)
            return;

        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<House>(out House house))
        {
            gameObject.SetActive(false);
        }
    }

}


