using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MoverPlayer : MonoBehaviour
{
    public delegate void EndPlayerTurn();
    public EndPlayerTurn onPlayerTurnEnd;
    [SerializeField] bool canRecievePos;
    [SerializeField] float ballXCordinate;
    [SerializeField] int ballsQuantity;
    [SerializeField] GameObject ballThatIndicatesWhereToMove;
    public static MoverPlayer instance;
    [HideInInspector] public bool oneTime;
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
        ballsQuantity = DispararBolas.instance.quantidadeBolasMax;
        canRecievePos = true;
        gameObject.SetActive(false);
        ballThatIndicatesWhereToMove.SetActive(false); 
        oneTime = true;
    }
    private void OnEnable()
    {
        ballsQuantity = DispararBolas.instance.quantidadeBolasMax;
        canRecievePos = true;
    }


    void Update()
    {
        if (ballsQuantity <= 0 && oneTime)
        {
            GameManager.state = GameState.MovementTurn;
            ballThatIndicatesWhereToMove.SetActive(false);
            onPlayerTurnEnd?.Invoke();
            StartCoroutine(MovePlayerToPos());
            oneTime = false;
        }
    }
    IEnumerator MovePlayerToPos()
    {
        float iterador = 0;
        Transform playerPos = DispararBolas.instance.transform;
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
            
        }
    }
}
