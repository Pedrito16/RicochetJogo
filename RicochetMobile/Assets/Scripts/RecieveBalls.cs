using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class RecieveBalls : MonoBehaviour
{
    public delegate void EndPlayerTurn();
    public EndPlayerTurn onPlayerTurnEnd;
    [SerializeField] bool canRecievePos;
    [SerializeField] float ballXCordinate;
    public int ballsQuantity;
    [SerializeField] GameObject ballThatIndicatesWhereToMove;
    DispararBolas dispararBolas;
    public static RecieveBalls instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        dispararBolas = DispararBolas.instance;
        ballsQuantity = dispararBolas.quantidadeBolasMax;
        canRecievePos = true;
        gameObject.SetActive(false);
        ballThatIndicatesWhereToMove.SetActive(false); 
    }
    public void PassTurn()
    {
        GameManager.state = GameState.MovementTurn;
        GameManager.howManyRoudsPassed += 1;
        ballThatIndicatesWhereToMove.SetActive(false);

        onPlayerTurnEnd?.Invoke();

        StartCoroutine(MovePlayerToPos());
        GameManager.instance.OnStateChange?.Invoke();

        ballsQuantity = dispararBolas.quantidadeBolasMax;
        ballThatIndicatesWhereToMove.SetActive(false);
        canRecievePos = true;
    }
    IEnumerator MovePlayerToPos()
    {
        float iterador = 0;
        Transform playerPos = dispararBolas.transform.parent;

        while (playerPos.position.x != ballXCordinate)
        {
            playerPos.position = Vector2.Lerp(playerPos.position, new Vector2(ballXCordinate,playerPos.position.y), iterador);
            iterador += Time.deltaTime;
            yield return null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out IResetPosWall target))
        {
            if (canRecievePos)
            {
                ballXCordinate = collision.transform.position.x;
                ballThatIndicatesWhereToMove.SetActive(true);
                ballThatIndicatesWhereToMove.transform.position = new Vector2(ballXCordinate, DispararBolas.instance.transform.position.y + 0.2f);
                canRecievePos = false;
            }
            ballsQuantity--;
            target.ResetPos();
            if(ballsQuantity <= 0)
                PassTurn();
        }
    }
}
