using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentarPorCaminhoPontosTransf : MonoBehaviour
{
    public Transform[] pontosCaminho;
    public bool reinicia;

    private Velocidade velocidadeComponent;
    private int indicePontoAtual;
    private Vector3 direcao;

    void Start()
    {
        if (!TryGetComponent<Velocidade>(out velocidadeComponent))
            print("Adicione o componente <color=orange>Velocidade</color> ao GameObject.");

        StartCoroutine(Movimenta());
    }

    IEnumerator Movimenta()
    {
        indicePontoAtual = 0;

        while (true)
        {
            direcao = pontosCaminho[indicePontoAtual].position - transform.position;
            direcao.Normalize();

            transform.position = Vector3.MoveTowards(transform.position,
                pontosCaminho[indicePontoAtual].position, velocidadeComponent.GetVelocidade() * Time.deltaTime);

            if (Vector3.Distance(transform.position, pontosCaminho[indicePontoAtual].position) < 0.3f)
            {
                indicePontoAtual++;

                if (indicePontoAtual >= pontosCaminho.Length)
                {
                    if (reinicia)
                    {
                        StartCoroutine(Movimenta());
                    }
                    else
                    {
                        velocidadeComponent.SetVelocidade(0);
                        yield break;
                    }
                }
            }

            transform.LookAt(pontosCaminho[indicePontoAtual]);

            yield return new WaitForEndOfFrame();
        }
    }
}
