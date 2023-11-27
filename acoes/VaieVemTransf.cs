using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaieVemTransf : MonoBehaviour
{
    public float distancia;
    public float velocidadeVai;
    public float velocidadeVolta;
    public Vector3 direcaoMovimento;
    public float tempoAntesDoVai;
    public float tempoAntesDaVolta;
    private float dist;
    private Rigidbody rb;
    private Rigidbody2D rb2D;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb2D = GetComponent<Rigidbody2D>();

        if (rb != null)
            StartCoroutine(VaiRigidbody());
        else if (rb2D != null)
            StartCoroutine(VaiRigidbody2D());
        else
            StartCoroutine(VaiTransf());
    }

    IEnumerator VaiTransf()
    {
        yield return new WaitForSeconds(tempoAntesDoVai);
        dist = distancia;

        while (dist > 0)
        {
            transform.Translate(direcaoMovimento * velocidadeVai * Time.deltaTime);
            dist -= velocidadeVai * Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(VoltaTransf());
    }

    IEnumerator VoltaTransf()
    {
        yield return new WaitForSeconds(tempoAntesDaVolta);
        dist = distancia;

        while (dist > 0)
        {
            transform.Translate(direcaoMovimento * -velocidadeVolta * Time.deltaTime);
            dist -= velocidadeVolta * Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(VaiTransf());
    }

    IEnumerator VaiRigidbody()
    {
        yield return new WaitForSeconds(tempoAntesDoVai);
        dist = distancia;

        while (dist > 0)
        {
            rb.MovePosition(transform.position + velocidadeVai * Time.fixedDeltaTime
                * direcaoMovimento);
            dist -= velocidadeVai * Time.fixedDeltaTime;

            yield return new WaitForFixedUpdate();
        }

        StartCoroutine(VoltaRigidbody());
    }

    IEnumerator VoltaRigidbody()
    {
        yield return new WaitForSeconds(tempoAntesDaVolta);
        dist = distancia;

        while (dist > 0)
        {
            rb.MovePosition(transform.position + -velocidadeVolta * Time.fixedDeltaTime
                * direcaoMovimento);
            dist -= velocidadeVolta * Time.fixedDeltaTime;

            yield return new WaitForFixedUpdate();
        }

        StartCoroutine(VaiRigidbody());
    }

    IEnumerator VaiRigidbody2D()
    {
        yield return new WaitForSeconds(tempoAntesDoVai);
        dist = distancia;

        while (dist > 0)
        {
            rb2D.MovePosition(transform.position + velocidadeVai * Time.fixedDeltaTime
                * direcaoMovimento);
            dist -= velocidadeVai * Time.fixedDeltaTime;

            yield return new WaitForFixedUpdate();
        }

        StartCoroutine(VoltaRigidbody2D());
    }

    IEnumerator VoltaRigidbody2D()
    {
        yield return new WaitForSeconds(tempoAntesDaVolta);
        dist = distancia;

        while (dist > 0)
        {
            rb2D.MovePosition(transform.position + -velocidadeVolta * Time.fixedDeltaTime
                * direcaoMovimento);
            dist -= velocidadeVolta * Time.fixedDeltaTime;

            yield return new WaitForFixedUpdate();
        }

        StartCoroutine(VaiRigidbody2D());
    }
}
