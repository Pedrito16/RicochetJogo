using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispararBolas : MonoBehaviour
{
    [Header("Essentials")]
    [SerializeField] Transform lineCircle;
    [SerializeField] LineRenderer lineRenderer;
    public int quantidadeBolasMax;
    [SerializeField] GameObject bolinha;

    [Header("Configurações")]
    [SerializeField] float velocidadeBolas;
    
    [Header("Debug")]
    public List<Rigidbody2D> ballsRbList;
    Vector2 mousePos;
    public bool allBallsShot = false;
    [SerializeField] bool alreadyShooted;
    [SerializeField] bool isOnBounds;
    public bool canShoot;

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
        //pool para bolinhas
        for (int i = 0; i < quantidadeBolasMax; i++)
        {
            GameObject ball = Instantiate(bolinha);
            ball.transform.SetParent(transform, false);
            ball.transform.position = transform.position;
            ball.SetActive(false);
            ballsRbList.Add(ball.GetComponent<Rigidbody2D>());
        }
        lineRenderer.enabled = false;
    }
    void Start()
    {
        canShoot = true;
        lineCircle.gameObject.SetActive(false);
        GameManager.instance.OnStateChange += OnEnemyTurnStart;
    }
    void OnEnemyTurnStart()
    {
        lineCircle.gameObject.SetActive(false);
        lineRenderer.enabled = false;
        canShoot = true;
        alreadyShooted = false;
        allBallsShot = false;
    }
    void Update()
    {
        if(GameManager.instance.state == GameState.PlayerTurn)
        {
            if (Input.GetMouseButton(0) && canShoot && !alreadyShooted)
            {
                lineRenderer.enabled = true;
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Aim();
            }
            if (Input.GetMouseButtonUp(0) && canShoot && !alreadyShooted && isOnBounds)
            {
                alreadyShooted = true;
                lineRenderer.enabled = false;
                lineCircle.gameObject.SetActive(false);
                StartCoroutine(ShotBalls(mousePos));
            }
        }
        

        lineRenderer.SetPosition(0, transform.parent.position);
        lineRenderer.SetPosition(1, new Vector3(mousePos.x,mousePos.y, 0));

        
    }
    void Aim()
    {
        if (mousePos.y > gameObject.transform.position.y)
        {
            lineRenderer.enabled = true;
            lineCircle.transform.position = mousePos;
            canShoot = true;
            isOnBounds = true;
            lineCircle.gameObject.SetActive(true);
        }
        else if (mousePos.y <= gameObject.transform.position.y)
        {
            isOnBounds = false;
            lineRenderer.enabled = false;
            lineCircle.gameObject.SetActive(false);
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
