using System.Collections;
using UnityEngine;

public class BasicEnemy : EnemyStatus
{
    public EnemyComponents components;

    Sprite originalSprite;
    Sprite takeDamageSprite;
    SpriteRenderer sr;
    EnemyMovement movementScript;
    [SerializeField] BarraDeVida lifeBar;
    public Inimigos currentEnemy;

    public bool canTakeDamage = true;
    private void Awake()
    {
        movementScript = components.movementScript; //pega o componente previamente pego
        lifeBar = GetComponent<BarraDeVida>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {

    }

    void Update()
    {
       
    }
    public void Setup(Sprite normalSprite)
    {
        originalSprite = normalSprite;
        sr.sprite = normalSprite;

        RecieveBalls.instance.onPlayerTurnEnd += components.movementScript.Move;
        lifeBar.Setup(Vida);
    }
    public override void TakeDamage(int damage)
    {
        if (!canTakeDamage) return;
        components.animator.SetTrigger("TakeDmg");
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
        RecieveBalls.instance.onPlayerTurnEnd -= components.movementScript.Move;
        gameObject.SetActive(false);
        lifeBar.ResetValues();
        EnemyConverter.instance.enemyPool.Enqueue(components);
    }
    public (AnimatorControllerParameterType? type, bool found) HasParameter(string parameterName, Animator animator = null)
    {
        if (animator == null) animator = components.animator;
        foreach(var parameter in animator.parameters)
        {
            if(parameter.name == parameterName)
            {
                return (parameter.type, true);
            }
        }
        return (null , true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            TakeDamage(1);
        }
    }

}
