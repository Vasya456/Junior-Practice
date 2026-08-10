using UnityEngine;

public class CubeSpawnerTask2 : MonoBehaviour
{

    [SerializeField] private float _explosionForce = 300f;
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private float _upwardModifier = 1f;



    private void ApplyExplosionForce(Rigidbody rigidbody, Vector3 explosionCentre) 
    {

        if (rigidbody == null)
            return;

        rigidbody.AddExplosionForce(_explosionForce, explosionCentre, _explosionRadius, _upwardModifier, ForceMode.Impulse);

    }
}
