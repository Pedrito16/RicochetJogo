using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyConverter : MonoBehaviour
{
    [SerializeField] GameObject originalObject;
    [SerializeField] int poolSize = 35;
    [SerializeField] Queue<GameObject> enemyPool = new Queue<GameObject>();

    [SerializeField] Queue<EnemyMovement> enemyMovementScript = new Queue<EnemyMovement>();

    [SerializeField] Queue<BasicEnemy> enemyLife = new Queue<BasicEnemy>();

    void Start()
    {
        for(int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(originalObject);
            EnemyMovement enemyMovement = obj.GetComponent<EnemyMovement>();
            BasicEnemy enemyStatus = obj.GetComponent<BasicEnemy>();

            obj.SetActive(false);

            enemyPool.Enqueue(obj);
            enemyMovementScript.Enqueue(enemyMovement);
            enemyLife.Enqueue(enemyStatus);
        }
    }
    public void SetEnemy(Inimigos newEnemy)
    {
        GameObject enemy = enemyPool.Dequeue();
        EnemyMovement movementScript = enemyMovementScript.Dequeue();
        BasicEnemy enemyStatus = enemyLife.Dequeue();

        enemyStatus.Vida = newEnemy.life;   
        movementScript.tilesDistance = newEnemy.tilesDistance;
        enemyStatus.SetSprites(newEnemy.normalSprite, newEnemy.damagedSprite);

        enemy.SetActive(true);
    }
}
