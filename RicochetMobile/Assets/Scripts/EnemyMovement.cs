using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyMovement : EnemyStatus
{
    [Range(1, 5)]
    public int tilesDistance = 1;

    [SerializeField] float velocidade;
    [SerializeField] int roundsToWin = 8;
    [SerializeField] int howManyRoundsSurvived = 1;
    public BasicEnemy enemyStats;

    private void Awake()
    {
        enemyStats = GetComponent<BasicEnemy>();
    }
    void Start()
    {
        
    }
    public void Move()
    {
        Abilities enemyAbility = enemyStats.currentEnemy.ability;

        if (enemyAbility != null && enemyAbility.activationMethod == AbilityActivationMethod.Round_End)
            enemyAbility?.UseAbility(enemyStats);

        howManyRoundsSurvived += tilesDistance;
            
        if (howManyRoundsSurvived >= roundsToWin)
        {
            DeathScreen.isDead = true;
        }
        StartCoroutine(MoveToNextTile());
    }
    public IEnumerator MoveToNextTile()
    {
        float iterador = 0;
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y - DistanciaMovimentação * tilesDistance, 0);
        while (transform.position != targetPosition)
        {
             transform.position = Vector2.Lerp(transform.position, targetPosition, iterador);
             iterador += Time.deltaTime * velocidade;
             yield return null;
        }
        //GameManager.state = GameState.PlayerTurn;
    }
}