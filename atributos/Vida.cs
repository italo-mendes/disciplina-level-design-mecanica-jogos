using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    [SerializeField]
    private int vida;

    // se VidaMaxima for zero, então o gameObject não terá vidaMaxima
    [SerializeField]
    private int vidaMaxima;

    public int GetVida()
    {
        return vida;
    }

    public void SetVida(int valor)
    {
        if (valor >= 0)
            if (vidaMaxima > 0)
            {
                if (valor > vidaMaxima)
                    vida = vidaMaxima;
                else
                    vida = valor;
            }
            else
            {
                vida = valor;
            }
        else
            vida = 0;
    }

    public int GetVidaMaxima()
    {
        return vidaMaxima;
    }

    public void SetVidaMaxima(int valor)
    {
        vidaMaxima = valor;
    }
}
