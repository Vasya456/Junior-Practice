using UnityEngine;

public class Places : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private Transform _points;
    private Transform[] arrayPlaces;
    private int NumberOfPlaceInArrayPlaces;
   
    
    private void Start()
    {
        arrayPlaces = new Transform[_points.childCount];

        for (int i = 0; i < _points.childCount; i++)
            arrayPlaces[i] = _points.GetChild(i).GetComponent<Transform>();
    }
   
  
    private void Update()
    {
        Transform spawnPosition = arrayPlaces[NumberOfPlaceInArrayPlaces];
        
        transform.position = Vector3.MoveTowards(transform.position, spawnPosition.position, _speed * Time.deltaTime);


        if (transform.position == spawnPosition.position) 
            NextPlaceTakerLogic();
    }
    private Vector3 NextPlaceTakerLogic()
    {
        NumberOfPlaceInArrayPlaces++;

        if (NumberOfPlaceInArrayPlaces == arrayPlaces.Length)
            NumberOfPlaceInArrayPlaces = 0;

        Vector3 direction = arrayPlaces[NumberOfPlaceInArrayPlaces].transform.position;
        transform.forward = direction - transform.position.normalized;
        return direction;


    }
}
