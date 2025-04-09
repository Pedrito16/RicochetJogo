using System.Collections;
using UnityEngine;

public class BasicEnemy : EnemyStatus
{
    [SerializeField] int life;
    EnemyMovement movementScript;
    private void Awake()
    {
        movementScript = GetComponent<EnemyMovement>();
    }
    private void Start()
    {
        Começar();
    }
    protected override void Começar()
    {
        base.Começar();
    }

    void Update()
    {
        life = Vida;
    }
    public override void TakeDamage(int damage)
    {
        Vida -= damage;
        print("To tomando dano ai ai aia iaia");
        if (Vida <= 0)
        {
            MoverPlayer.instance.onPlayerTurnEnd -= movementScript.Move;
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            TakeDamage(1);
        }
    }
}
