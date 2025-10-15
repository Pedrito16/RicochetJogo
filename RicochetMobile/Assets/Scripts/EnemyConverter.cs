using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class EnemyComponents
{
    public GameObject enemy;
    public EnemyMovement movementScript;
    public BasicEnemy enemyLife;

    public EnemyComponents(GameObject enemy, EnemyMovement movementScript, BasicEnemy enemyLife)
    {
        this.enemy = enemy;
        this.movementScript = movementScript;
        this.enemyLife = enemyLife;
        this.enemyLife.components = this;
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
            GameObject obj = Instantiate(originalObject);
            EnemyComponents enemyComponent = new EnemyComponents(obj, obj.GetComponent<EnemyMovement>(), obj.GetComponent<BasicEnemy>());

            obj.SetActive(false);
            enemyPool.Enqueue(enemyComponent);
        }
    }

    void Start()
    {
        
    }
    public EnemyComponents GetEnemy(Inimigos newEnemy)
    {
        EnemyComponents enemyComponent = enemyPool.Dequeue();

        enemyComponent.movementScript.tilesDistance = newEnemy.tilesDistance;
        enemyComponent.enemyLife.Vida = newEnemy.life;
        enemyComponent.enemyLife.SetSprites(newEnemy.normalSprite, newEnemy.damagedSprite);

        enemyComponent.enemy.SetActive(true);
        return enemyComponent;
    }
}
