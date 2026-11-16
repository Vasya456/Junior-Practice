using UnityEngine;

public class Apples : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player)) 
        {
            Destroy(gameObject);
        }
    }
}
