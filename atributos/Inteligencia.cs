using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inteligencia : MonoBehaviour
{
    [SerializeField]
    private int inteligencia;

    public void setInteligencia(int valor)
    {
        if(valor >= 0)
        {
            inteligencia = valor;
        }

    }

    public int getInteligencia()
    {
        return inteligencia;
    }
}
