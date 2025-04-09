using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] GameObject[] enemiesPrefabs;
    [SerializeField] Transform initialSpawnPosition;
    [SerializeField] int spawnChance;
    [SerializeField] float espaçamento;
    [SerializeField] int rows;
    EnemyManager enemyManager;
    void Start()
    {
        enemyManager = GetComponent<EnemyManager>();
        for (int i = 0; i < rows; i++)
        {
            int numeroAleatorio = Random.Range(0, spawnChance);
            Vector3 spawnPos = initialSpawnPosition.position + new Vector3(i * espaçamento,0,0);
            if(numeroAleatorio <= 5)
            {
                GameObject enemy = Instantiate(enemiesPrefabs[0], spawnPos, enemiesPrefabs[0].transform.rotation);
                enemyManager.enemies.Add(enemy.GetComponent<EnemyMovement>());
            }
        }
    }
    void Update()
    {
        
    }
}
