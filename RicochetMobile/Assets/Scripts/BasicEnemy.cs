using System.Collections;
using UnityEngine;

public class BasicEnemy : EnemyStatus
{
    [SerializeField] int life;
    void Start()
    {
        Vida = 6;
    }

    
    void Update()
    {
        life = Vida;
    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }
}
