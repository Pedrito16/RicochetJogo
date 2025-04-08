using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour, IResetPosWall
{
    [SerializeField] Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnBecameInvisible()
    {
        rb.linearVelocity = Vector3.zero;
        transform.position = DispararBolas.instance.transform.position;
        gameObject.SetActive(false);
    }
    public void ResetPos()
    {
        transform.position = DispararBolas.instance.transform.position;
        rb.linearVelocity = Vector3.zero;
        gameObject.SetActive(false);
    }
    
}
