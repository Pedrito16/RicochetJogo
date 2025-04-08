using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispararBolas : MonoBehaviour
{
    public int quantidadeBolasMax;
    [SerializeField] GameObject bolinha;
    [Header("Configura��es")]
    [SerializeField] float velocidadeBolas;
    
    [Header("Debug")]
    [SerializeField] List<Rigidbody2D> ballsRbList;
    Vector3 mousePos;
    public static DispararBolas instance;
    // variaveis fora do console
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
    }

    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            Touch touch = Input.GetTouch(0);
            Debug.DrawRay(transform.position, ballsRbList[0].transform.position);
            mousePos = Camera.main.ScreenToWorldPoint(touch.position);
        }
        if (Input.touchCount > 0 && Input.GetMouseButtonUp(0))
        {
            print("atirando bolas na posi��o: " + mousePos);
            StartCoroutine(ShotBalls(mousePos)); 
        }

        
    }
    IEnumerator ShotBalls(Vector3 mousePos)
    {
        print("atirando bolas");
        for(int i = 0; i < ballsRbList.Count; i++)
        {
            /*Vector2 position = ballsRbList[i].transform.position  mousePos;
            position = position.normalized;*/
            Vector2 distance = (mousePos - ballsRbList[i].transform.position).normalized;
            ballsRbList[i].gameObject.SetActive(true);
            ballsRbList[i].linearVelocity = distance * velocidadeBolas;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
