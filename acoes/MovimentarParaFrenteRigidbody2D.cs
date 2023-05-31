using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class MovimentarParaFrenteRigidbody2D : MonoBehaviour
{
    private Rigidbody2D rb;
    private Velocidade velocidadeComponent;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (!TryGetComponent<Velocidade>(out velocidadeComponent))
            print("Adicione o componente <color=orange>Velocidade</color> ao GameObject.");
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + velocidadeComponent.GetVelocidade() 
            * Time.deltaTime * transform.right);
    }
}
