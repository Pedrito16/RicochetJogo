using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyStatus : MonoBehaviour
{

    private int vida;

    public int Vida { get => vida; set => vida = value; }
}
