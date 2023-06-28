using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovimentarEmCurvaRigidbody2D : MonoBehaviour
{
    public float velocidade;
    public float anguloInicialMinimo;
    public float anguloInicialMaximo;
    public float velocidadeRotacao;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Definir ângulo inicial aleatório dentro do intervalo
        float anguloInicial = Random.Range(anguloInicialMinimo, anguloInicialMaximo);
        transform.rotation = Quaternion.Euler(0f, 0f, anguloInicial);
    }

    private void FixedUpdate()
    {
        // Calcular o vetor de movimento
        Vector2 movimento = transform.right * velocidade * Time.fixedDeltaTime;

        // Aplicar o movimento usando MovePosition do Rigidbody2D
        rb.MovePosition(rb.position + movimento);

        // Girar o gameObject
        transform.Rotate(0f, 0f, velocidadeRotacao * Time.fixedDeltaTime);
    }
}
