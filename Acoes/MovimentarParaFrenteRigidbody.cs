using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class MovimentarParaFrenteRigidbody : MonoBehaviour
{
    private Rigidbody rb;
    private Velocidade velocidadeComponent;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (!TryGetComponent<Velocidade>(out velocidadeComponent))
            print("Adicione o componente <color=orange>Velocidade</color> ao GameObject.");
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + velocidadeComponent.GetVelocidade()
            * Time.deltaTime * transform.forward);
    }
}