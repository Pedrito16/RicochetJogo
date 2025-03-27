using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispararBolas : MonoBehaviour
{
    [SerializeField] GameObject bolinha;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.WorldToScreenPoint(Input.mousePosition);
            print(mousePos);
            GameObject bola = Instantiate(bolinha, mousePos, bolinha.transform.rotation);
        }   
    }
}
