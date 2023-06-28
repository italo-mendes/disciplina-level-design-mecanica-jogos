using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentarEmCurvaRigidbody : MonoBehaviour
{
    public float velocidade;
    public float anguloInicialMinimo;
    public float anguloInicialMaximo;
    public float velocidadeRotacao;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        float anguloInicial = Random.Range(anguloInicialMinimo, anguloInicialMaximo);
        transform.rotation = Quaternion.Euler(0f, anguloInicial, 0f);
    }

    private void FixedUpdate()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");

        // Movimentar para frente usando o eixo Z local
        Vector3 movimento = transform.forward * movimentoVertical * velocidade * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movimento);

        // Rotação do objeto
        float rotacao = movimentoHorizontal * velocidadeRotacao * Time.fixedDeltaTime;
        Quaternion rotacaoObjeto = Quaternion.Euler(0f, rotacao, 0f);
        rb.MoveRotation(rb.rotation * rotacaoObjeto);
    }
}

