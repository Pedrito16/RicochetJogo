using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] GameObject[] enemiesPrefabs;
    [SerializeField] Transform initialSpawnPosition;
    [SerializeField] int spawnChance;
    [SerializeField] float espaçamento;
    [SerializeField] int rows;
    EnemyManager enemyManager;
    private void Awake()
    {
        
    }
    void Start()
    {
        MoverPlayer.instance.onPlayerTurnEnd += InstantiateNextRow;
        MoverPlayer.instance.onPlayerTurnEnd += UpgradeEnemies;
        enemyManager = GetComponent<EnemyManager>();
        InstantiateNextRow();
    }
    void InstantiateNextRow()
    {
        StartCoroutine(InstantiateRows());
    }
    IEnumerator InstantiateRows()
    {
        for (int i = 0; i < rows; i++)
        {
            int numeroAleatorio = Random.Range(0, spawnChance);
            Vector3 spawnPos = initialSpawnPosition.position + new Vector3(i * espaçamento, 0, 0);
            if (numeroAleatorio <= 5)
            {
                Instantiate(enemiesPrefabs[0], spawnPos, enemiesPrefabs[0].transform.rotation);
            }
        }
        yield return new WaitForSeconds(0.2f);
        GameManager.state = GameState.PlayerTurn;
    }
    void UpgradeEnemies()
    {
        int numeroDeVidasAdicionais = Mathf.FloorToInt(GameManager.howManyRoudsPassed / 2);
        EnemyStatus.vidaBase = 6 + numeroDeVidasAdicionais;
        print("aumentando vida para:" + EnemyStatus.vidaBase.ToString());
    }
    void Update()
    {
        
    }
}
