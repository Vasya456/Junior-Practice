using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _points;
    private Transform[] Points;
    private int _currentPointIndex;
   
    
    private void Start()
    {
        Points = new Transform[_points.childCount];

        for (int i = 0; i < _points.childCount; i++)
            Points[i] = _points.GetChild(i).GetComponent<Transform>();
    }
   
  
    private void Update()
    {
        Transform spawnPosition = Points[_currentPointIndex];
        
        transform.position = Vector3.MoveTowards(transform.position, spawnPosition.position, _speed * Time.deltaTime);


        if (transform.position == spawnPosition.position) 
            NextPlaceTakerLogic();
    }
    private Vector3 NextPlaceTakerLogic()
    {
        _currentPointIndex++;

        if (_currentPointIndex == Points.Length)
            _currentPointIndex = 0;

        Vector3 direction = Points[_currentPointIndex].transform.position;
        transform.forward = (direction - transform.position).normalized;
        return direction;


    }
}
