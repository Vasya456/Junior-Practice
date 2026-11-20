using UnityEngine;

public class Health : MonoBehaviour
{

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.TakeHealth(10);
            Destroy(gameObject);
        }
    }
}
