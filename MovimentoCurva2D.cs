using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoCurva2D : MonoBehaviour
{

    public float forca = 10f;
    public float raioCurva = 5f;
    public float velocidadeAngular = 2f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        Vector2 direcaoCurva = new Vector2(Mathf.Sin(Time.time * velocidadeAngular), Mathf.Cos(Time.time * velocidadeAngular));
        
        rb.AddForce(direcaoCurva * forca);

        Vector2 posicaoCurva = direcaoCurva.normalized * raioCurva;
        rb.MovePosition(posicaoCurva);
    }
}
