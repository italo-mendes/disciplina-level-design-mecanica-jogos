using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacaoConstante : MonoBehaviour
{
    public float velocidadeRotacao;
    public Boolean rotacionarNoEixoX;
    public Boolean rotacionarNoEixoY;
    public Boolean rotacionarNoEixoZ;
    private Vector3 eixos;

    void Start()
    {
        if (rotacionarNoEixoX)
            eixos.x = 1.0f;

        if (rotacionarNoEixoY)
            eixos.y = 1.0f;

        if (rotacionarNoEixoZ)
            eixos.z = 1.0f;
    }

    void Update()
    {
        transform.Rotate(Time.deltaTime * velocidadeRotacao * eixos, Space.Self);
    }
}
