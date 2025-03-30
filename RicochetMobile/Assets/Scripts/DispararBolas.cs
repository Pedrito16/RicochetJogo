using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispararBolas : MonoBehaviour
{
    [SerializeField] int quantidadeBolasMax;
    [SerializeField] GameObject bolinha;
    [Header("Configurações")]
    [SerializeField] float velocidadeBolas;
    
    [Header("Debug")]
    [SerializeField] List<Rigidbody2D> ballsRbList;
    Vector3 mousePos;
    // variaveis fora do console
    private void Awake()
    {

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
            Vector2 absMouse = new Vector2(Mathf.Abs(mousePos.x), Mathf.Abs(mousePos.y));
            Vector2 absTransform = new Vector2(Mathf.Abs(transform.position.x), Mathf.Abs(transform.position.y));
            
            Vector2 location = (absTransform - (Vector2)mousePos).normalized;
            
            Touch touch = Input.GetTouch(0);
            Debug.DrawRay(transform.position, location);
            mousePos = Camera.main.ScreenToWorldPoint(touch.position);

        }
        if (Input.touchCount > 0 && Input.GetMouseButtonUp(0))
        {
            print("atirando bolas na posição: " + mousePos);
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
            Vector2 location = transform.position - mousePos;
            ballsRbList[i].gameObject.SetActive(true);
            ballsRbList[i].velocity = mousePos * velocidadeBolas;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
