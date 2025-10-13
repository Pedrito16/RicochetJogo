using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyStatus : MonoBehaviour
{
    private float distanciaMovimentação = 0.9f;
    public static int vidaBase = 6;
    [SerializeField] private int vida;
    public static EnemyStatus instance;

    public int Vida { get => vida; set => vida = value; }
    public float DistanciaMovimentação { get => distanciaMovimentação; set => distanciaMovimentação = value; }
    private void Awake()
    {
        
    }
    protected virtual void Começar()
    {
        Vida = vidaBase;
    }
    public virtual void TakeDamage(int damage)
    {
        Vida -= damage;
    }
}
