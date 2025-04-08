using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyStatus : MonoBehaviour
{

    private int vida;

    public int Vida { get => vida; set => vida = value; }

    public virtual void TakeDamage(int damage)
    {
        Vida -= damage;
        if (Vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
