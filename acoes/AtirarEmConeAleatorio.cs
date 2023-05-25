using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtirarEmArco : MonoBehaviour
{
    public GameObject projetil;
    [SerializeField]
    private float tempoEntreDisparos;
    [SerializeField]
    private float anguloDoCone;
    private float aleatoriedadeNaDirecao;
    private Quaternion rotacaoInicial;

    void Start()
    {
        rotacaoInicial = transform.localRotation;

        StartCoroutine(Atira());
    }

    IEnumerator Atira()
    {
        while (true)
        {
            aleatoriedadeNaDirecao = Random.Range(-(anguloDoCone/2),(anguloDoCone/2));
            
            transform.Rotate(0.0f, aleatoriedadeNaDirecao, 0.0f, Space.Self);
            Instantiate(projetil, transform.position, transform.rotation);

            transform.localRotation = rotacaoInicial;

            yield return new WaitForSeconds(tempoEntreDisparos);
        }
    }
}
