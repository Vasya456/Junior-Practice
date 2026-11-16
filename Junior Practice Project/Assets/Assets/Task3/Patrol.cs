using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _pointsPosition;
    private Transform[] _points;
    private int _currentPointIndex;


    private void Start()
    {
        _points = new Transform[_pointsPosition.childCount];

        for (int i = 0; i < _points.Length; i++)
            _points[i] = _pointsPosition.GetChild(i);
    }


    private void Update()
    {
        Transform target = _points[_currentPointIndex];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position) 
        {
            _currentPointIndex = (_currentPointIndex + 1) % _points.Length;
            transform.LookAt(_points[_currentPointIndex]);
        }
    }
}
