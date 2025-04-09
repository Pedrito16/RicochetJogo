using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyStatus : MonoBehaviour
{
    private float distanciaMovimenta��o = 0.75f;
    private int vida;

    public int Vida { get => vida; set => vida = value; }
    public float DistanciaMovimenta��o { get => distanciaMovimenta��o; set => distanciaMovimenta��o = value; }

    public virtual void TakeDamage(int damage)
    {
        Vida -= damage;
        if (Vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
