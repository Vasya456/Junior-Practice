using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _aim;
    [SerializeField] private float _speed;



    private void Update()
    {
        Move();
    }


    private void Move() 
    {
        transform.position = Vector3.Lerp(transform.position, _aim.position, _speed * Time.deltaTime);
    }
}
