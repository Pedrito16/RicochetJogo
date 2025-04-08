using UnityEngine;

public class MoverPlayer : MonoBehaviour
{
    [SerializeField] bool canRecievePos;
    [SerializeField] float ballXCordinate;
    [SerializeField] int ballsQuantity;
    
    void Start()
    {
        ballsQuantity = DispararBolas.instance.quantidadeBolasMax;
        canRecievePos = true;
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        ballsQuantity = DispararBolas.instance.quantidadeBolasMax;
        canRecievePos = true;
    }


    void Update()
    {
        if(ballsQuantity <= 0)
        {
            GameManager.state = GameState.MovementTurn;
            DispararBolas.instance.transform.position = new Vector2(ballXCordinate, DispararBolas.instance.transform.position.y);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out IResetPosWall target))
        {
            if (canRecievePos)
            {
                ballXCordinate = collision.transform.position.x;
                canRecievePos = false;
            }
            ballsQuantity--;
            target.ResetPos();
        }
    }
}
