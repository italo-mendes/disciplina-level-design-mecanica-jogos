using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentarParaAlvoTransf : MonoBehaviour
{
    public Transform alvo;
    private Velocidade velocidadeComponent;

    void Start()
    {
        if (!TryGetComponent<Velocidade>(out velocidadeComponent))
            print("Adicione o componente <color=orange>Velocidade</color> ao GameObject.");
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position, alvo.position, velocidadeComponent.GetVelocidade() * Time.deltaTime);
    }
}
