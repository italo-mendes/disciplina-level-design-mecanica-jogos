using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class AvancoCurtoRigidbody : MonoBehaviour
{

    //AINDA NAO TERMINEI, SÓ ESTOU SAlVANDO PARA ATUALIZAR EM CASA

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
            
    }

    void FixedUpdate()
    {

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

            while (distanciaDoAvanco > 0)
            {
                rb.MovePosition(transform.position + velocidadeDoAvanco
                    * Time.deltaTime * eixosDeAvanco);

                distanciaDoAvanco -= Time.deltaTime * velocidadeDoAvanco;
            }
        }

        

    }

}
