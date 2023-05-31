using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsquivarAleatorioRigidbody2D : MonoBehaviour
{
    public float tempoMinimoEsquiva;
    public float tempoMaximoEsquiva;
    public float distancia;
    public float velocidadeEsquiva;
    public Boolean esquivaNoEixoX;
    public Boolean esquivaNoEixoY;
    public Boolean esquivaNoEixoZ;
    private Vector3 eixos;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (tempoMaximoEsquiva == 0)
            tempoMaximoEsquiva = tempoMinimoEsquiva;

        tempoMaximoEsquiva++;

        StartCoroutine(Esquiva());
    }

    IEnumerator Esquiva()
    {
        while (true)
        {
            yield return new WaitForSeconds(
                UnityEngine.Random.Range(tempoMinimoEsquiva, tempoMaximoEsquiva));

            StartCoroutine(Movimenta());
        }
    }

    IEnumerator Movimenta()
    {
        float dist = distancia;

        if (esquivaNoEixoX)
            eixos.x = UnityEngine.Random.Range(-1, 2);

        if (esquivaNoEixoY)
            eixos.y = UnityEngine.Random.Range(-1, 2);

        if (esquivaNoEixoZ)
            eixos.z = UnityEngine.Random.Range(-1, 2);

        while (dist > 0)
        {
            rb.MovePosition(transform.position + velocidadeEsquiva
                * Time.deltaTime * eixos);

            dist -= Time.deltaTime * velocidadeEsquiva;

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
