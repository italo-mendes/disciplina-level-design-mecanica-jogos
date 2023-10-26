using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerador : MonoBehaviour
{
    public GameObject prefab; 
    public int quantidade;
    public float tempoAntesGerar;
    public float intervaloMinimo;
    public float intervaloMaximo;
    public bool seraDestruido;
    public List<float> listaIntervalos = new List<float>();
    public float xMinimo;
    public float xMaximo;
    public float yMinimo;
    public float yMaximo;
    public float zMinimo;
    public float zMaximo;

    private void Start()
    {
        if (quantidade > 0)
            StartCoroutine(GerarObjetosQuantidade());
        else if (listaIntervalos.Count > 0)
            StartCoroutine(GerarObjetosListaIntervalos());
        else
            StartCoroutine(GerarObjetosIlimitado());
    }

    private IEnumerator GerarObjetosQuantidade()
    {
        yield return new WaitForSeconds(tempoAntesGerar);

        while (quantidade > 0)
        {
            Instantiate(prefab, transform.position
                + new Vector3(Random.Range(xMinimo, xMaximo), 
                              Random.Range(yMinimo, yMaximo), 
                              Random.Range(zMinimo, zMaximo)), 
                transform.rotation);

            quantidade--;

            yield return new WaitForSeconds(
                Random.Range(intervaloMinimo, intervaloMaximo));
        }

        if (seraDestruido)
            Destroy(gameObject);
    }

    private IEnumerator GerarObjetosListaIntervalos()
    {
        yield return new WaitForSeconds(tempoAntesGerar);

        for (int i = 0; i < listaIntervalos.Count; i++)
        {
            Instantiate(prefab, transform.position
                + new Vector3(Random.Range(xMinimo, xMaximo),
                              Random.Range(yMinimo, yMaximo),
                              Random.Range(zMinimo, zMaximo)),
                transform.rotation);

            yield return new WaitForSeconds(listaIntervalos[i]);
        }

        if (seraDestruido)
            Destroy(gameObject);
    }

    private IEnumerator GerarObjetosIlimitado()
    {
        yield return new WaitForSeconds(tempoAntesGerar);

        while (true)
        {
            Instantiate(prefab, transform.position
                + new Vector3(Random.Range(xMinimo, xMaximo),
                              Random.Range(yMinimo, yMaximo),
                              Random.Range(zMinimo, zMaximo)),
                transform.rotation);

            yield return new WaitForSeconds(
                Random.Range(intervaloMinimo, intervaloMaximo));
        }
    }
}
