using System.Collections;
using UnityEngine;

public class MovimentarPorCaminhoPontosRigidbody : MonoBehaviour
{
    public Transform[] pontosCaminho;
    public bool reinicia;

    private Velocidade velocidadeComponent;
    private int indicePontoAtual;
    private Rigidbody rb;
    private Vector3 direcao;

    private void Start()
    {
        if (!TryGetComponent<Velocidade>(out velocidadeComponent))
            print("Adicione o componente <color=orange>Velocidade</color> ao GameObject.");

        rb = GetComponent<Rigidbody>();
        StartCoroutine(Movimenta());
    }

    IEnumerator Movimenta()
    {
        indicePontoAtual = 0;

        while (true)
        {
            direcao = pontosCaminho[indicePontoAtual].position - transform.position;
            direcao.Normalize();

            rb.MovePosition(transform.position + direcao
                * velocidadeComponent.GetVelocidade() * Time.deltaTime);

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
                        rb.velocity = Vector3.zero;
                        yield break;
                    }
                }
            }

            transform.LookAt(pontosCaminho[indicePontoAtual]);

            yield return new WaitForEndOfFrame();
        }
    }
}
