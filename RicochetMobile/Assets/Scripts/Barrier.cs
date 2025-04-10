using UnityEngine;

public class Barrier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            print("Colidindo");
            DeathScreen.isDead = true;
        }
    }
}
