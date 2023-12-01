using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtirarEmCirculo : MonoBehaviour
{
    public GameObject projetil;
    public int numeroDirecoes;
    public float tempoEntreDisparos;
    public float tempoMinimoAntesComecarAtirar;
    public float tempoMaximoAntesComecarAtirar;
    //public float raioDosDisparos;
    public bool eixoX;
    public bool eixoY;
    public bool eixoZ;
    private float angulo;
    private Quaternion rotacaoInicial;
    private Vector3 posInicial;
    private Vector3 posPadrao;
    private IEnumerator coroutine;

    void OnEnable()
    {
        AtualizaAngulos();
        rotacaoInicial = transform.localRotation;
        posPadrao = transform.localPosition;

        coroutine = AtiraContinuamente();
        StartCoroutine(coroutine);
    }

    IEnumerator AtiraContinuamente()
    {
        yield return new WaitForSeconds(
            Random.Range(tempoMinimoAntesComecarAtirar, tempoMaximoAntesComecarAtirar));

        while (true)
        {
            Atira();

            yield return new WaitForSeconds(tempoEntreDisparos);
        }
    }

    public void Atira()
    {
        posInicial = transform.position;

        if (eixoX)
            for (int i = 0; i < numeroDirecoes; i++)
            {
                transform.position = posInicial;
                transform.Rotate(1.0f * angulo, 0.0f, 0.0f, Space.Self);
                //transform.Translate(0.0f, raioDosDisparos, 0.0f);
                Instantiate(projetil, transform.position, transform.rotation);
            }

        transform.localRotation = rotacaoInicial;

        if (eixoY)
            for (int i = 0; i < numeroDirecoes; i++)
            {
                transform.position = posInicial;
                transform.Rotate(0.0f, 1.0f * angulo, 0.0f, Space.Self);
                //transform.Translate(raioDosDisparos, 0.0f , 0.0f);

                if (eixoX)
                    if (transform.localRotation.eulerAngles.y == 90 ||
                        transform.localRotation.eulerAngles.y == 270)
                        continue;

                Instantiate(projetil, transform.position, transform.rotation);
            }

        transform.localRotation = rotacaoInicial;

        if (eixoZ)
            for (int i = 0; i < numeroDirecoes; i++)
            {
                transform.position = posInicial;
                transform.Rotate(0.0f, 0.0f, 1.0F * angulo, Space.Self);
                //transform.Translate(0.0f, raioDosDisparos, 0.0f);

                if (eixoX)
                    if (transform.localRotation.eulerAngles.z == 0 ||
                        transform.localRotation.eulerAngles.z == 180)
                        continue;

                if (eixoY)
                    if (transform.localRotation.eulerAngles.z == 90 ||
                        transform.localRotation.eulerAngles.z == 270)
                        continue;

                Instantiate(projetil, transform.position, transform.rotation);
            }

        transform.localRotation = rotacaoInicial;
    }

    public void AtualizaAngulos()
    {
        angulo = 360 / numeroDirecoes;
    }

    public void SetProjetil(GameObject proj)
    {
        projetil = proj;
    }

    public void SetNumeroDirecoes(int numDir)
    {
        numeroDirecoes = numDir;
        AtualizaAngulos();
    }

    public void VariacaoNumeroDirecoes(int variacao)
    {
        numeroDirecoes += variacao;

        if (numeroDirecoes <= 0)
            numeroDirecoes = 1;

        AtualizaAngulos();
    }

    void OnDisable()
    {
        transform.localPosition = posPadrao;

        StopCoroutine(coroutine);
    }
}
