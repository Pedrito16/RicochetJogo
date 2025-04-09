using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyMovement : EnemyStatus
{
    [SerializeField] float velocidade;
    public bool isReadyToGo;
    [SerializeField] int quantasVezesSeMexeu;
    void Start()
    {
        MoverPlayer.instance.onPlayerTurnEnd += Move;
        quantasVezesSeMexeu = 1;
    }

    
    void Update()
    {
    }
    void Move()
    {
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
        isReadyToGo = true;
        GameManager.state = GameState.PlayerTurn;
    }
}