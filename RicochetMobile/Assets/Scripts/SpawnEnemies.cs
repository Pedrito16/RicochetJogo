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

    [Header("Enemy Info")]

    EnemyManager enemyManager;
    private void Awake()
    {
        
    }
    void Start()
    {
        MapsChanger.instance.OnMapSwitch += ChangeEnemies;
        RecieveBalls.instance.onPlayerTurnEnd += InstantiateNextRow;
        RecieveBalls.instance.onPlayerTurnEnd += UpgradeEnemies;
        InstantiateNextRow();
    }
    void ChangeEnemies(CenarioSO cenario)
    {
        enemiesPrefabs = cenario.enemiesToSpawn.ToArray();
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
                int inimigoAleatorio = Random.Range(0, enemiesPrefabs.Length);
                Instantiate(enemiesPrefabs[inimigoAleatorio], spawnPos, enemiesPrefabs[0].transform.rotation);
            }
        }
        yield return new WaitForSeconds(0.2f);
        GameManager.instance.state = GameState.PlayerTurn;
    }
    void UpgradeEnemies()
    {
        int numeroDeVidasAdicionais = Mathf.FloorToInt(GameManager.instance.howManyRoudsPassed / 2);
        EnemyStatus.vidaBase = 6 + numeroDeVidasAdicionais;
        print("aumentando vida para:" + EnemyStatus.vidaBase.ToString());
    }
}
