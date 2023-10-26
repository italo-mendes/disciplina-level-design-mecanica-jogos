using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentarEmUmEixoRigidbody2D : MonoBehaviour
{
    public bool eixoX;
    public bool eixoY;
    public bool proprioEixo;
    private Rigidbody2D rb;
    private Velocidade velocidadeComponent;
    private Vector3 direcaoMovimento;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direcaoMovimento = Vector3.zero;

        if (!proprioEixo)
        {
            if (eixoX)
                direcaoMovimento.x = 1.0f;

            if (eixoY)
                direcaoMovimento.y = 1.0f;
        }

        if (!TryGetComponent<Velocidade>(out velocidadeComponent))
            print("Adicione o componente <color=orange>Velocidade</color> ao GameObject.");
    }

    void FixedUpdate()
    {
        if (proprioEixo)
        {
            if (eixoX)
                rb.MovePosition(transform.position + velocidadeComponent.GetVelocidade()
                    * Time.deltaTime * transform.right);

            else if (eixoY)
                rb.MovePosition(transform.position + velocidadeComponent.GetVelocidade()
                    * Time.deltaTime * transform.up);
        }
        else
        {
            rb.MovePosition(transform.position + velocidadeComponent.GetVelocidade()
                    * Time.deltaTime * direcaoMovimento);
        }
    }
}
