using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentarEmCurvaRigidbody: MonoBehaviour
{
    public float velocidade;
    public float raioCurva;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        float x = raioCurva * Mathf.Cos(Time.time * velocidade);
        float y = 0f;
        float z = raioCurva * Mathf.Sin(Time.time * velocidade);

       
        Vector3 direcao = new Vector3(x, y, z) - rb.position;

        rb.AddForce(direcao.normalized * velocidade);
    }
}
