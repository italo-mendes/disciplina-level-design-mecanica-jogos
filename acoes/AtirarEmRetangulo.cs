using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AtirarEmRetangulo : MonoBehaviour
{
    public GameObject projetil;
    public int quantidadeLinhas;
    public float tempoEntreDisparos;
    public float tempoMinimoAntesComecarAtirar;
    public float tempoMaximoAntesComecarAtirar;
    public float distanciaLinhaDeTiros;
    public bool eixoX;
    public bool eixoY;
    public bool eixoZ;
    private float ajuste;
    private float metadeDaDistancia;
    private Vector3 deslocamentoInicial;
    private Vector3 deslocamento;
    private Vector3 posInicial;
    private IEnumerator coroutine;

    void Start()
    {
        deslocamento = Vector3.zero;

        if (eixoX)
            deslocamento.x = 1.0f;

        if (eixoY)
            deslocamento.y = 1.0f;

        if (eixoZ)
            deslocamento.z = 1.0f;

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
        metadeDaDistancia = distanciaLinhaDeTiros / 2;

        if (quantidadeLinhas % 2 == 0)
            ajuste = -((((quantidadeLinhas / 2) - 1) * distanciaLinhaDeTiros) + metadeDaDistancia);
        else
            ajuste = (-quantidadeLinhas / 2) * distanciaLinhaDeTiros;

        if (eixoX)
            deslocamentoInicial.x = ajuste;

        if (eixoY)
            deslocamentoInicial.y = ajuste;

        if (eixoZ)
            deslocamentoInicial.z = ajuste;

        transform.position += deslocamentoInicial;

        for (int i = 0; i < quantidadeLinhas; i++)
        {
            Instantiate(projetil,
                transform.position + (deslocamento * i * distanciaLinhaDeTiros), 
                transform.rotation);
        }

        transform.position = posInicial;
    }

    public void SetProjetil(GameObject proj)
    {
        projetil = proj;
    }

    public void SetQuantidadeLinhas(int quant)
    {
        quantidadeLinhas = quant;
    }

    public void VariacaoQuantidadeLinhas(int variacao)
    {
        quantidadeLinhas += variacao;

        if (quantidadeLinhas <= 0)
            quantidadeLinhas = 1;
    }

    public void SetDistanciaLinhaDeTiros(int dist)
    {
        distanciaLinhaDeTiros = dist;
    }

    public void VariacaoDistanciaLinhaDeTiros(int variacao)
    {
        distanciaLinhaDeTiros += variacao;

        if (distanciaLinhaDeTiros <= 0)
            distanciaLinhaDeTiros = 1;
    }

    void OnDisable()
    {
        StopCoroutine(coroutine);
    }
}
