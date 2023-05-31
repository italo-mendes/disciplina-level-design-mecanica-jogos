using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentarParaFrenteAleatorioTransf : MonoBehaviour
{
    [SerializeField]
    private Velocidade velocidade;
    [SerializeField]
    private float tempoDeMovimentacao;
    [SerializeField]
    private float anguloMin;
    [SerializeField]
    private float anguloMax;

    void Start()
    {
        if (!TryGetComponent<Velocidade>(out velocidade))
            print("Adicione o componente <color=orange>Velocidade</color> ao GameObject.");
        StartCoroutine(Movimentar());
    }

    IEnumerator Movimentar()
    {
        while (true)
        {
            float total = 0.0f;
            while (total <= tempoDeMovimentacao)
            {
                transform.Translate(velocidade.GetVelocidade() * Time.deltaTime * transform.forward);
                total += Time.deltaTime;

                yield return new WaitForEndOfFrame();
            }

            float angulo = Random.Range(anguloMin, anguloMax);
            transform.Rotate(0.0f, angulo, 0.0f);

            yield return new WaitForEndOfFrame();
        }
    }
}
