using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtirarEmConeAleatorio : MonoBehaviour
{
    public GameObject projetil;
    public float tempoEntreDisparos;
    public float tempoMinimoAntesComecarAtirar;
    public float tempoMaximoAntesComecarAtirar;
    public float anguloDoCone;
    public Vector3 eixosTiros;
    private float aleatoriedadeNaDirecao;
    private Quaternion rotacaoInicial;
    private float metadeAnguloDoCone;

    void Start()
    {
        AtualizaAngulos();
        rotacaoInicial = transform.localRotation;

        StartCoroutine(AtiraContinuamente());
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
        aleatoriedadeNaDirecao = Random.Range(-metadeAnguloDoCone, metadeAnguloDoCone);

        transform.Rotate(eixosTiros * aleatoriedadeNaDirecao, Space.Self);
        Instantiate(projetil, transform.position, transform.rotation);

        transform.localRotation = rotacaoInicial;
    }

    public void AtualizaAngulos()
    {
        metadeAnguloDoCone = anguloDoCone / 2;
    }

    public void SetProjetil(GameObject proj)
    {
        projetil = proj;
    }

    public void SetAnguloDoCone(float angulo)
    {
        anguloDoCone = angulo;
        AtualizaAngulos();
    }

    public void VariacaoAnguloDoCone(float variacao)
    {
        anguloDoCone += variacao;

        if (anguloDoCone <= 0.0f)
            anguloDoCone = 1.0f;

        AtualizaAngulos();
    }
}
