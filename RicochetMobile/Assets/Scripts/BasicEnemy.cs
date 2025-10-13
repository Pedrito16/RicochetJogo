using System.Collections;
using UnityEngine;

public class BasicEnemy : EnemyStatus
{
    [SerializeField] int life;
    Sprite originalSprite;
    Sprite takeDamageSprite;

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
    public void SetSprites(Sprite normalSprite, Sprite damagedSprite)
    {
        originalSprite = normalSprite;
        takeDamageSprite = damagedSprite;
    }
    public override void TakeDamage(int damage)
    {
        Vida -= damage;
        if (Vida <= 0)
        {
            RecieveBalls.instance.onPlayerTurnEnd -= movementScript.Move;
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
