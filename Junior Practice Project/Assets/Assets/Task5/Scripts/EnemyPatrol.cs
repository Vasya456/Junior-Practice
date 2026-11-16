using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _wayPoints;

    private int _currentIndex = 0;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Patrol();   
    }


    private void Patrol() 
    {
        if (_wayPoints == null || _wayPoints.Length == 0)
            return;

        Transform waypoint = _wayPoints[_currentIndex];

        _spriteRenderer.flipX = waypoint.position.x < transform.position.x;

        transform.position = Vector3.MoveTowards(transform.position, waypoint.position, _speed * Time.deltaTime);

        if (transform.position == waypoint.position)
        {
            _currentIndex = (_currentIndex + 1) % _wayPoints.Length;
        }
    }

}
