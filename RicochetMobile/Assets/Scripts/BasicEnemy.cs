using System.Collections;
using UnityEngine;

public class BasicEnemy : EnemyStatus
{
    public EnemyComponents components;

    Sprite originalSprite;
    Sprite takeDamageSprite;

    SpriteRenderer spriteRenderer;
    EnemyMovement movementScript;
    [SerializeField] BarraDeVida lifeBar;
    private void Awake()
    {
        lifeBar = GetComponent<BarraDeVida>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
       
    }
    public void SetSprites(Sprite normalSprite, Sprite damagedSprite)
    {
        originalSprite = normalSprite;
        takeDamageSprite = damagedSprite;

        spriteRenderer.sprite = normalSprite;
        lifeBar.Setup(vidaBase);
    }
    public override void TakeDamage(int damage)
    {
        Vida -= damage;
        lifeBar.TomarDano(Vida);

        if (Vida <= 0)
        {
            print("ai ai to morrendo me ajuda");
            OnDie();
        }
    }
    void OnDie()
    {
        RecieveBalls.instance.onPlayerTurnEnd -= movementScript.Move;
        gameObject.SetActive(false);
        lifeBar.ResetValues();
        EnemyConverter.instance.enemyPool.Enqueue(components);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            TakeDamage(1);
        }
    }
}
