using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyStatus : MonoBehaviour
{
    private float distanciaMovimenta��o = 0.9f;
    public static int vidaBase = 6;
    [SerializeField] private int vida;
    public static EnemyStatus instance;

    public int Vida { get => vida; set => vida = value; }
    public float DistanciaMovimenta��o { get => distanciaMovimenta��o; set => distanciaMovimenta��o = value; }
    private void Awake()
    {
        
    }
    protected virtual void Come�ar()
    {
        Vida = vidaBase;
    }
    public virtual void TakeDamage(int damage)
    {
        Vida -= damage;
    }
}
