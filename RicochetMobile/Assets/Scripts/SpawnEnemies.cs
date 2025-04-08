using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] GameObject[] enemiesPrefabs;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] int spawnChance;
    void Start()
    {
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            int numeroAleatorio = Random.Range(0, spawnChance);
            if(numeroAleatorio >= 5)
            Instantiate(enemiesPrefabs[0], spawnPoints[i].position, enemiesPrefabs[0].transform.rotation);
        }
    }
    void Update()
    {
        
    }
}
