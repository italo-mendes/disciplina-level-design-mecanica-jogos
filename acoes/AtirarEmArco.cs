using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtirarEmArco : MonoBehaviour
{
    public GameObject projetil;
    public int numeroDirecoes;
    public float tempoEntreDisparos;
    public float tempoMinimoAntesComecarAtirar;
    public float tempoMaximoAntesComecarAtirar;
    private int angulo;
    private Quaternion rotacaoInicial;

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
        // 90, pois é a metade de 180 graus
        transform.Rotate(0.0f, 0.0f, -(90 - (angulo / 2)), Space.Self);
        Instantiate(projetil, transform.position, transform.rotation);

        // for (int i = 2; i <= numeroDirecoes; i++)
        // OU
        for (int i = 1; i <= numeroDirecoes - 1; i++)
        {
            transform.Rotate(0.0f, 0.0f, angulo, Space.Self);
            Instantiate(projetil, transform.position, transform.rotation);
        }

        transform.localRotation = rotacaoInicial;
    }

    public void AtualizaAngulos()
    {
        angulo = 180 / numeroDirecoes;
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
}
