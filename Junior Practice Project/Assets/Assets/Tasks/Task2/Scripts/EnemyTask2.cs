using UnityEngine;

public class EnemyTask2 : MonoBehaviour
{
    [SerializeField] private float _speedTask2;
    [SerializeField] private Transform _target;

    private Vector3 _direction;

    private void Update()
    {
        MoveTask2();    
    }

    public void SetTarget(Transform target) 
    {
        _target = target;
    }

    private void MoveTask2()
    {
        if (_target == null)
            return;

        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speedTask2 * Time.deltaTime);     
    }
}
