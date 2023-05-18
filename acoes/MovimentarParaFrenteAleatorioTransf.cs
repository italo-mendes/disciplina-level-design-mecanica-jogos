using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentarParaFrenteAleatorioTransf : MonoBehaviour
{
    [SerializeField]
    private float velocidade;
    [SerializeField]
    private float tempoDeMovimentacao;
    [SerializeField]
    private float anguloMin;
    [SerializeField]
    private float anguloMax;

    void Start()
    {
        StartCoroutine(Movimentar());
    }

    IEnumerator Movimentar()
    {
        while (true)
        {
            float total = 0.0f;
            while (total <= tempoDeMovimentacao)
            {
                transform.Translate(velocidade * Time.deltaTime * new Vector3(0.0f, 0.0f, 1.0f));
                total += Time.deltaTime;

                yield return new WaitForEndOfFrame();
            }

            float angulo = Random.Range(anguloMin, anguloMax);
            transform.Rotate(0.0f, angulo, 0.0f);

            yield return new WaitForEndOfFrame();
        }
    }
}
