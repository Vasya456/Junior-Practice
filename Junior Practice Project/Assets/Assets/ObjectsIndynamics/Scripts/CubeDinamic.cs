using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeDinamic : MonoBehaviour
{
    [SerializeField] private ChangeColor _changeColor;

   [SerializeField] private float _minRangeDelete = 2;
   [SerializeField] private float _maxRanageDelete = 5;

    private bool _hasCollided = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane") && _hasCollided == false)
        {
            _hasCollided = true;
            _changeColor.ApplyRandomColor(gameObject);
            
            float delay = Random.Range(_minRangeDelete, _maxRanageDelete);
            Destroy(gameObject, delay);

        }
    }
}
