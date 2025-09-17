using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ball : MonoBehaviour, IResetPosWall
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] Vector2 ballDirection;
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
    void LateUpdate()
    {
        Vector2 velocity = rb.linearVelocity;
        if (velocity.sqrMagnitude > 0.01f)
        {
            float angulo = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angulo - 90f, Vector3.forward); //copiei do gpt, gira a bola para cima
                                                                                      //fiz isso para os efeitos ficarem sempre olhando para cima
        }
    }
    public void ResetPos()
    {
        transform.position = DispararBolas.instance.transform.position;
        rb.linearVelocity = Vector3.zero;
        gameObject.SetActive(false);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        float randomPitch = Random.Range(0.8f, 1.2f);
        audioSource.pitch = randomPitch;
        audioSource.PlayOneShot(audioSource.clip);
        if (collision.gameObject.TryGetComponent(out EnemyStatus enemy))
        {
            enemy.TakeDamage(damage);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            ResetPos();
        }
    }
    public void RotateBall()
    {
        
    }
}
