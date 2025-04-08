using UnityEngine;

public class MoverPlayer : MonoBehaviour
{
    [SerializeField] bool canRecievePos;
    [SerializeField] Vector2 movePlayerToPos;
    [SerializeField] int ballsQuantity;
    void Start()
    {
        ballsQuantity = DispararBolas.instance.quantidadeBolasMax;
        canRecievePos = true;
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out IResetPosWall target))
        {
            if (canRecievePos)
            {
                movePlayerToPos = collision.transform.position;
                canRecievePos = false;
            }
            target.ResetPos();
        }
    }
}
