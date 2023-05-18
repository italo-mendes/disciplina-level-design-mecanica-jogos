using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField]
    public int quantidadeDeBalas;

    [SerializeField]
    public int quantidadeMaximaDeBalas;

    public int GetQuantidadeBalas()
    {
        return quantidadeDeBalas;
    }

    public void SetQuantidadeDeBalas(int valor)
    {
        if(quantidadeMaximaDeBalas > 0.0f)
        {
            if(valor <= quantidadeMaximaDeBalas)
            {
                quantidadeDeBalas = valor;
            }
            else
            {
                quantidadeDeBalas = valor;
            }
        }
    }

    public int GetQuantidadeMaximaDeBalas()
    {
        return quantidadeMaximaDeBalas;
    }

    public void SetQuantidadeMaximaDeBalas(int valor)
    {
        quantidadeMaximaDeBalas = valor;
    }

}
