using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtirarEmConeAleatorio : MonoBehaviour
{
    public GameObject projetil;
    [SerializeField]
    private float tempoEntreDisparos;
    [SerializeField]
    private float anguloDoCone;
    private float aleatoriedadeNaDirecao;
    private Quaternion rotacaoInicial;
    private float metadeAnguloDoCone;

    void Start()
    {
        rotacaoInicial = transform.localRotation;
        metadeAnguloDoCone = anguloDoCone / 2;

        StartCoroutine(Atira());
    }

    IEnumerator Atira()
    {
        while (true)
        {
            aleatoriedadeNaDirecao = Random.Range(-metadeAnguloDoCone,metadeAnguloDoCone);
            
            transform.Rotate(0.0f, aleatoriedadeNaDirecao, 0.0f, Space.Self);
            Instantiate(projetil, transform.position, transform.rotation);

            transform.localRotation = rotacaoInicial;

            yield return new WaitForSeconds(tempoEntreDisparos);
        }
    }
}
