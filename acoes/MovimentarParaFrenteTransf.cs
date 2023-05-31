using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class MovimentarParaFrenteTransf : MonoBehaviour
{
    private Velocidade velocidadeComponent;

    void Start()
    {
        if (!TryGetComponent<Velocidade>(out velocidadeComponent))
            print("Adicione o componente <color=orange>Velocidade</color> ao GameObject.");
    }

    void FixedUpdate()
    {
        transform.Translate(velocidadeComponent.GetVelocidade()
            * Time.deltaTime * transform.forward);
    }
}
