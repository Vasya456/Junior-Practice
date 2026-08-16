using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeTask2 : MonoBehaviour
{
    [SerializeField] private float _chance;

    private void Awake() 
    {
        if (TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            rb.useGravity = false;
            rb.isKinematic = true;
        }
    }

    public float Chance => _chance;

    public void SetChance(float chance) 
    {
        _chance = chance;
    }
    

}
