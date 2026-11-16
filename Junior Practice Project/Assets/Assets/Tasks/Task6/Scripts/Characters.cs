using UnityEngine;

public class Characters : MonoBehaviour
{
    [SerializeField] private float _maxhealth;

    private float _currentHealth;


    private void Start()
    {
        _currentHealth = _maxhealth;
    }
}
