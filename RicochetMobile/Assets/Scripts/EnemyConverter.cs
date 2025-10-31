using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class EnemyComponents
{
    public GameObject enemy;
    public Animator animator;
    public EnemyMovement movementScript;
    public BasicEnemy enemyLife;

    public EnemyComponents(GameObject enemy, EnemyMovement movementScript, BasicEnemy enemyLife, Animator animator)
    {
        this.enemy = enemy;
        this.movementScript = movementScript;
        this.enemyLife = enemyLife;
        this.enemyLife.components = this;
        this.animator = animator;
    }
}
public class EnemyConverter : MonoBehaviour
{
    [SerializeField] GameObject originalObject;
    [SerializeField] int poolSize = 35;

    [HideInInspector] public Queue<EnemyComponents> enemyPool = new Queue<EnemyComponents>();
    public static EnemyConverter instance;
    private void Awake()
    {
        instance = this;
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(originalObject, transform);
            EnemyComponents enemyComponent = new EnemyComponents(obj, obj.GetComponent<EnemyMovement>(), obj.GetComponent<BasicEnemy>(), obj.GetComponent<Animator>());

            obj.SetActive(false);
            enemyPool.Enqueue(enemyComponent);
        }
    }

    void Start()
    {
        
    }
    public EnemyComponents GetEnemy(Inimigos newEnemy, int lifeInRounds)
    {
        EnemyComponents enemyComponent = enemyPool.Dequeue();

        enemyComponent.movementScript.tilesDistance = newEnemy.tilesDistance;
        enemyComponent.enemyLife.Vida = newEnemy.life + lifeInRounds;
        enemyComponent.enemyLife.currentEnemy = newEnemy;
        enemyComponent.enemyLife.Setup(newEnemy.mainSprite);
        enemyComponent.animator.runtimeAnimatorController = newEnemy.animatorController;

        enemyComponent.enemy.SetActive(true);
        return enemyComponent;
    }
}
