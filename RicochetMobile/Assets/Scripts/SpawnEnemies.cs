using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] GameObject[] enemiesPrefabs;
    [SerializeField] Transform initialSpawnPosition;
    [SerializeField] int spawnChance;
    [SerializeField] float espašamento;
    [SerializeField] int rows;
    void Start()
    {
        for(int i = 0; i < rows; i++)
        {
            int numeroAleatorio = Random.Range(0, spawnChance);
            Vector3 spawnPos = initialSpawnPosition.position + new Vector3(i * espašamento,0,0);

            if(numeroAleatorio <= 5)
            {
                GameObject enemy = Instantiate(enemiesPrefabs[0], spawnPos, enemiesPrefabs[0].transform.rotation);
            }
        }
    }
    void Update()
    {
        
    }
}
