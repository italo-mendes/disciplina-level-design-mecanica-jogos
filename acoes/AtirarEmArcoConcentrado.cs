using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtirarEmArcoConcentrado : MonoBehaviour
{
    public GameObject projetil;
    public int numeroDirecoes;
    public float tempoEntreDisparos;
    public float anguloEntreDirecoes;
    private float angulo;
    private float anguloTotal;
    private Quaternion rotacaoInicial;

    void Start()
    {
        anguloTotal = anguloEntreDirecoes * (numeroDirecoes - 1);
        angulo = anguloTotal / numeroDirecoes;
        rotacaoInicial = transform.localRotation;

        StartCoroutine(Atira());
    }

    IEnumerator Atira()
    {
        while (true)
        {
            transform.Rotate(0.0f, -((anguloTotal/2) - (angulo / 2)), 0.0f, Space.Self);
            Instantiate(projetil, transform.position, transform.rotation);

            for (int i = 1; i <= numeroDirecoes - 1; i++)
            {
                transform.Rotate(0.0f, anguloEntreDirecoes, 0.0f, Space.Self);
                Instantiate(projetil, transform.position, transform.rotation);
            }

            transform.localRotation = rotacaoInicial;

            yield return new WaitForSeconds(tempoEntreDisparos);
        }
    }
}
