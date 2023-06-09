using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class AvancoCurtoRigidbody : MonoBehaviour
{
    [SerializeField]
    private float distanciaDoAvanco;
    [SerializeField]
    private float velocidadeDoAvanco;

    private Vector3 eixosDeAvanco;

    [SerializeField]
    private Boolean avancarNoEixoX;
    [SerializeField]
    private Boolean avancarNoEixoY;
    [SerializeField]
    private Boolean avancarNoEixoZ;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        StartCoroutine(Avancar());
    }

    IEnumerator Avancar()
    {
        float dist = distanciaDoAvanco;

        if (!avancarNoEixoX & !avancarNoEixoY & !avancarNoEixoZ)
        {
            print("Selecione ao menos um dos eixos para o qual o objeto avançará");
        }
        else
        {
            if (avancarNoEixoX)
            {
                eixosDeAvanco.x = 1.0f;
            }

            if (avancarNoEixoY)
            {
                eixosDeAvanco.y = 1.0f;
            }

            if (avancarNoEixoZ)
            {
                eixosDeAvanco.z = 1.0f;
            }

            while (dist > 0)
            {
                rb.MovePosition(transform.position + velocidadeDoAvanco
                    * Time.deltaTime * eixosDeAvanco);

                dist -= Time.deltaTime * velocidadeDoAvanco;
                yield return new WaitForSeconds(Time.deltaTime);
            }
        }
    }

}
