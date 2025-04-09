using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispararBolas : MonoBehaviour
{
    [Header("Essentials")]
    [SerializeField] Transform lineCircle;
    [SerializeField] LineRenderer lineAim;
    public int quantidadeBolasMax;
    [SerializeField] GameObject bolinha;

    [Header("Configurações")]
    [SerializeField] float velocidadeBolas;
    
    [Header("Debug")]
    public List<Rigidbody2D> ballsRbList;
    Vector2 mousePos;
    public bool allBallsShot = false;
    [SerializeField] bool alreadyShooted;
    [SerializeField] bool canShoot;

    // variaveis fora do console
    public static DispararBolas instance;
    private void Awake()
    {
        if(instance == null)
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
        //pool para bolinhas
        for(int i = 0; i < quantidadeBolasMax; i++)
        {
            GameObject ball = Instantiate(bolinha);
            ball.transform.SetParent(transform, false);
            ball.transform.position = transform.position;
            ball.SetActive(false);
            ballsRbList.Add(ball.GetComponent<Rigidbody2D>());
        }
        lineAim.enabled = false;
    }

    void Update()
    {
        if (GameManager.state == GameState.MovementTurn)
        {
            lineCircle.gameObject.SetActive(false);
            lineAim.enabled = false;
            canShoot = true;
            alreadyShooted = false;
            allBallsShot = false;
        }
        if(GameManager.state == GameState.PlayerTurn && Input.touchCount > 0)
        {
            if (Input.GetMouseButton(0) && canShoot && !alreadyShooted)
            {
                lineAim.enabled = true;
                Touch touch = Input.GetTouch(0);
                Debug.DrawRay(transform.position, ballsRbList[0].transform.position);
                mousePos = Camera.main.ScreenToWorldPoint(touch.position);
            }
            if (Input.GetMouseButtonUp(0) && canShoot && !alreadyShooted)
            {
                alreadyShooted = true;
                print("atirando bolas na posição: " + mousePos);
                StartCoroutine(ShotBalls(mousePos));
            }
        }
        

        lineAim.SetPosition(0, transform.position);
        lineAim.SetPosition(1, new Vector3(mousePos.x,mousePos.y, 0));
        if(mousePos.y > gameObject.transform.position.y + 0.25f && !alreadyShooted)
        {
            canShoot = true;
            lineAim.enabled = true;
            lineCircle.gameObject.SetActive(true);
            
        }
        else if(mousePos.y <= gameObject.transform.position.y + 0.25f&& !alreadyShooted)
        {
            lineAim.enabled = false;
            lineCircle.gameObject.SetActive(false);
            canShoot = false;
        }
    }
    IEnumerator ShotBalls(Vector3 mousePos)
    {
        print("atirando bolas");
        for(int i = 0; i < ballsRbList.Count; i++)
        {
            Vector2 distance = mousePos - ballsRbList[i].transform.position;
            distance = distance.normalized;
            ballsRbList[i].gameObject.SetActive(true);
            ballsRbList[i].linearVelocity = distance * velocidadeBolas;
            yield return new WaitForSeconds(0.1f);
        }
        allBallsShot = true;
    }
}
