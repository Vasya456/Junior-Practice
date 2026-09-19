using UnityEngine;

public class TargetPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private float _speed;

    private int _currentIndex = 0;

    private void Update()
    {
        if (_wayPoints == null || _wayPoints.Length == 0)
            return;

        Transform waypoint = _wayPoints[_currentIndex];
        transform.position = Vector3.MoveTowards(transform.position, waypoint.position, _speed * Time.deltaTime);

        if (transform.position == waypoint.position) 
        {
            _currentIndex = (_currentIndex + 1) % _wayPoints.Length;
        }
    }

}
