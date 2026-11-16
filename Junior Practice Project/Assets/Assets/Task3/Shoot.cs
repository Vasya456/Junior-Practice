using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shoot : MonoBehaviour
{
    [SerializeField] private float _value;
    [SerializeField] private GameObject _prefab; 
    [SerializeField] private float _timeWaitShooting;
    [SerializeField] private Transform _target;

    private Rigidbody _rigidbody;
    private bool _isWork = true;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        StartCoroutine(ShootingCooldown());
    }
   private IEnumerator ShootingCooldown()
    {        
        while (_isWork)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            GameObject bullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

            _rigidbody.transform.up = direction;
            _rigidbody.linearVelocity = direction * _value;

            yield return new WaitForSeconds(_timeWaitShooting);
        }
    }
}