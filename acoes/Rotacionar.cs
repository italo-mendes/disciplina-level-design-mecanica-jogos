using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacionar : MonoBehaviour
{
    public float velocidadeRotacao;
    public float anguloMinimo;
    public float anguloMaximo;
    public float tempoAntesRotacionar;
    public int eixoX;
    public int eixoY;
    public int eixoZ;
    private Vector3 vetorRotacao;
    private float angulo;
    private int sinal;

    void Start()
    {
        sinal = -1;
        angulo = anguloMinimo;

        if (eixoX != 0)
            vetorRotacao.x = eixoX;

        if (eixoY != 0)
            vetorRotacao.y = eixoY;

        if (eixoZ != 0)
            vetorRotacao.z = eixoZ;


        if (anguloMinimo == anguloMaximo)
            StartCoroutine(RotacaoInfinita());
        else
            StartCoroutine(RotacaoVaieVolta());
    }

    IEnumerator RotacaoInfinita()
    {
        yield return new WaitForSeconds(tempoAntesRotacionar);

        while (true)
        {
            angulo += sinal * velocidadeRotacao * Time.deltaTime;

            transform.localRotation = Quaternion.Euler(vetorRotacao * angulo);

            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator RotacaoVaieVolta()
    {
        yield return new WaitForSeconds(tempoAntesRotacionar);

        while (true)
        {
            angulo += sinal * velocidadeRotacao * Time.deltaTime;

            if (angulo > anguloMaximo)
            {
                sinal *= -1;
                angulo = anguloMaximo;
            }
            else if (angulo < anguloMinimo)
            {
                sinal *= -1;
                angulo = anguloMinimo;
            }

            transform.localRotation = Quaternion.Euler(vetorRotacao * angulo);

            yield return new WaitForEndOfFrame();
        }
    }
}
