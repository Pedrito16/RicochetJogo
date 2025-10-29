using System.Collections;
using UnityEngine;

public class MagicBarrierInstance : MonoBehaviour
{
    CircleCollider2D circleCol;
    Animator animator;

    public int health;
    private void Start()
    {
        animator = GetComponent<Animator>();
        circleCol = GetComponent<CircleCollider2D>();

        animator.SetBool("BarrierActive", true);
    }
    public void Setup(int newHealth = 5)
    {
        health = newHealth;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            health = Mathf.Clamp(health - 1, 0, health);
            if(health <= 0)
            {
                StartCoroutine(DestroyBarrier());
            }
        }
    }
    IEnumerator DestroyBarrier()
    {
        animator.SetBool("BarrierActive", false);
        circleCol.enabled = false;
        yield return new WaitForSeconds(1.2f);
        Destroy(gameObject);
    }
}
