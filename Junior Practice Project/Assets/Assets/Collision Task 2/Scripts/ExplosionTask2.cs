using UnityEngine;

public class ExplosionTask2 : MonoBehaviour
{
    [SerializeField] private float _explosionForceTask2 = 300f;
    [SerializeField] private float _explosionRadiusTask2 = 6f;
    [SerializeField] private float _upwardModifierTask2 = 1.5f;
    [SerializeField] private float _referenceScale = 1f;
    [SerializeField] private float _minCubeScale = 0.01f;

    public void Explode(Vector3 explosionCentre, float cubeScale, GameObject exploderIgnore) 
    {

        cubeScale = Mathf.Max(cubeScale, _minCubeScale);

        float sizeFactor = _referenceScale / cubeScale;
       
        sizeFactor = Mathf.Clamp(sizeFactor, 0.5f, 4f);

        float radius = _explosionRadiusTask2 * sizeFactor;
        float force = _explosionForceTask2 * sizeFactor;

        Collider[] hitColliders = Physics.OverlapSphere(explosionCentre, radius);

        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider == null)
                continue;

            if (exploderIgnore != null && hitCollider.gameObject == exploderIgnore)
                continue;

            Rigidbody rigidbody = hitCollider.attachedRigidbody;

            if (rigidbody == null)
                continue;

            rigidbody.isKinematic = false;
            rigidbody.useGravity = true;


            ApplyExplosionForce2(rigidbody, explosionCentre, radius, force);
        }
    }

    private void ApplyExplosionForce2(Rigidbody rigidbody, Vector3 explosionCentre,  float radius, float force)
    {
        if (rigidbody == null)
            return;
   
        rigidbody.AddExplosionForce(force, explosionCentre, radius, _upwardModifierTask2, ForceMode.Impulse);
    }
}
