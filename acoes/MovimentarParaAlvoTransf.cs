using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentarParaAlvoTransf : MonoBehaviour
{
    public Transform transform;

    private Velocidade velocidadeComponent;

     void Start()
    {
        if (!TryGetComponent<Velocidade>(out velocidadeComponent))
            print("Adicione o componente <color=orange>Velocidade</color> ao GameObject.");
    }

    void Update()
    {
        transform.LookAt(transform);
        transform.Translate(
            velocidadeComponent.GetVelocidade() * Time.deltaTime * transform.forward);
    }

}