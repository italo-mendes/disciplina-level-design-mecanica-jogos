using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentarEmUmEixoTransf : MonoBehaviour
{
    public bool eixoX;
    public bool eixoY;
    public bool eixoZ;
    public bool proprioEixo;
    private Velocidade velocidadeComponent;
    private Vector3 direcaoMovimento;

    void Start()
    {
        direcaoMovimento = Vector3.zero;

        if (!proprioEixo)
        {
            if (eixoX)
                direcaoMovimento.x = 1.0f;

            if (eixoY)
                direcaoMovimento.y = 1.0f;

            if (eixoZ)
                direcaoMovimento.z = 1.0f;
        }

        if (!TryGetComponent<Velocidade>(out velocidadeComponent))
            print("Adicione o componente <color=orange>Velocidade</color> ao GameObject.");
    }

    void Update()
    {
        if (proprioEixo)
        {
            if (eixoX)
                transform.Translate(velocidadeComponent.GetVelocidade()
                    * Time.deltaTime * transform.right);

            else if (eixoY)
                transform.Translate(velocidadeComponent.GetVelocidade()
                    * Time.deltaTime * transform.up);

            else if (eixoZ)
                transform.Translate(velocidadeComponent.GetVelocidade()
                    * Time.deltaTime * transform.forward);
        }
        else
        {
            transform.Translate(velocidadeComponent.GetVelocidade()
                * Time.deltaTime * direcaoMovimento);
        }
    }
}
