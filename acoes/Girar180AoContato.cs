using System;
using System.Collections;
using UnityEngine;

public class Girar180AoContato : MonoBehaviour
{
    public string tagDoAcionador;
    public Vector3 eixosRotacao;
    public float velocidadeRotacao;
    public float tempoParaVoltar;

    public bool rotacaoAtivada;
    private float angulo;

    void Start()
    {
        rotacaoAtivada = false;   
    }

    public IEnumerator Rotacionar180Graus(float tempoVoltar)
    {
        angulo = 180;

        while (angulo > 0)
        {
            angulo -= velocidadeRotacao * Time.deltaTime;
            transform.Rotate(eixosRotacao * velocidadeRotacao * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }

        if (tempoVoltar > 0)
        {
            yield return new WaitForSeconds(tempoVoltar);
            StartCoroutine(Rotacionar180Graus(0));
        }
        else if (tempoVoltar == 0)
            rotacaoAtivada = false;
    }

    void OnCollisionEnter(Collision outro)
    {
        if (outro.gameObject.CompareTag(tagDoAcionador) && !rotacaoAtivada)
        {
            rotacaoAtivada = true;
            StartCoroutine(Rotacionar180Graus(tempoParaVoltar));
        }
    }

    void OnTriggerEnter(Collider outro)
    {
        if (outro.gameObject.CompareTag(tagDoAcionador) && !rotacaoAtivada)
        {
            rotacaoAtivada = true;
            StartCoroutine(Rotacionar180Graus(tempoParaVoltar));
        }
    }

    void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag(tagDoAcionador) && !rotacaoAtivada)
        {
            rotacaoAtivada = true;
            StartCoroutine(Rotacionar180Graus(tempoParaVoltar));
        }
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag(tagDoAcionador) && !rotacaoAtivada)
        {
            rotacaoAtivada = true;
            StartCoroutine(Rotacionar180Graus(tempoParaVoltar));
        }
    }
}