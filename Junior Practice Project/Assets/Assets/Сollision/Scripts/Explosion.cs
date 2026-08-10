using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 300f;
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private float _upwardModifier = 1f;

    public void ApplyExplisionForce(Rigidbody rigidbody, Vector3 explosionCenter)
    {
        if (rigidbody == null)
            return;

        rigidbody.AddExplosionForce(_explosionForce, explosionCenter, _explosionRadius, _upwardModifier, ForceMode.Impulse);
    }
}
