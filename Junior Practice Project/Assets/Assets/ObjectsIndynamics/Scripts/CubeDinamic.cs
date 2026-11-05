using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeDinamic : MonoBehaviour
{
    [SerializeField] private ColorChanger _changeColor;
    [SerializeField] private float _minRangeDelete = 2;
    [SerializeField] private float _maxRanageDelete = 5;
    [SerializeField] private float _fallLimitY = -20f;
    private ObjectPool _objectPool;

    private bool _hasCollided = false;
    private Coroutine _returnCoroutine;
    private Rigidbody _rigidbody;

    public event Action<CubeDinamic> Released;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (transform.position.y < _fallLimitY)
            Release();
    }
    public void ResetState() 
    {
        _hasCollided = false;

        if (_returnCoroutine != null) 
        {
            StopCoroutine(_returnCoroutine);
            _returnCoroutine = null;
        }
        
        _changeColor.ResetColor();

        _rigidbody.linearVelocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;     
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_hasCollided)
            return;

        if (collision.gameObject.TryGetComponent<Plane>(out Plane plane))
        {
            _hasCollided = true;
            
            if(_changeColor.TryGetComponent(out Renderer renderer))
            _changeColor.ApplyRandomColor(renderer);

            float delay = UnityEngine.Random.Range(_minRangeDelete, _maxRanageDelete);
            _returnCoroutine = StartCoroutine(ReleaseAfterDelay(delay));
        }
    }

    private IEnumerator ReleaseAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Release();
    }

    private void Release()
    {
        Released?.Invoke(this);
    }

}
