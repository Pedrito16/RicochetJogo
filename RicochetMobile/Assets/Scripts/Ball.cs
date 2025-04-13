using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour, IResetPosWall
{
    [SerializeField] Rigidbody2D rb;
    public int damage;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        damage = 1;
    }
    void OnBecameInvisible()
    {
//eu adoro Ronaldo 
        rb.linearVelocity = Vector3.zero;
        transform.position = DispararBolas.instance.transform.position;
        gameObject.SetActive(false);
    }
    public void ResetPos()
    {
        transform.position = DispararBolas.instance.transform.position;
        rb.linearVelocity = Vector3.zero;
        gameObject.SetActive(false);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyStatus enemy))
        {
            enemy.TakeDamage(damage);
            print("Colidindo com enemy");
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            ResetPos();
        }
    }
}
