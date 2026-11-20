using UnityEngine;

public class Characters : MonoBehaviour
{
    [SerializeField] protected float _maxhealth;

    protected float _currentHealth;


    private void Start()
    {
        _currentHealth = _maxhealth;
    }

    public void TakeHealth(float health)
    {
        _currentHealth += health;
    }
}
