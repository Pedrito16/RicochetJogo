using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyMovement : EnemyStatus
{
    [SerializeField] float velocidade;
    [SerializeField] int howManyRoundsSurvived;
    public bool isReadyToGo;
    void Start()
    {
        MoverPlayer.instance.onPlayerTurnEnd += Move;
    }

    
    void Update()
    {
        
    }
    public void Move()
    {
        if (howManyRoundsSurvived >= 5)
        {
            DeathScreen.isDead = true;
        }
        else
        {
            howManyRoundsSurvived++;
        }
        StartCoroutine(MoveToNextTile());
    }
    public IEnumerator MoveToNextTile()
    {
        float iterador = 0;
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y - DistanciaMovimentação, 0);
        while (transform.position != targetPosition)
        {
             transform.position = Vector2.Lerp(transform.position, targetPosition, iterador);
             iterador += Time.deltaTime * velocidade;
             yield return null;
        }
        //GameManager.state = GameState.PlayerTurn;
    }
}