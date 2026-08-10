using UnityEngine;

public class CubeInfo : MonoBehaviour
{
    [SerializeField] private float _chance;
    public float Chance => _chance;

    public void SetChance(float chance)
    {
        _chance = chance;
    }
}
