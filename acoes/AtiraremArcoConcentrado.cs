using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtirarEmArco : MonoBehaviour
{
    public GameObject projetil;
    public int numeroDirecoes;
    public float tempoEntreDisparos;
    public float anguloEntreDirecoes;
    private float angulo;
    private Quaternion rotacaoInicial;

    void Start()
    {
        angulo = anguloEntreDirecoes * numeroDirecoes;
        rotacaoInicial = transform.localRotation;

        StartCoroutine(Atira());
    }

    IEnumerator Atira()
    {
        while (true)
        {
            transform.Rotate(0.0f,  (angulo/ 2)*-1, 0.0f, Space.Self);
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