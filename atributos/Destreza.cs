using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destreza: MonoBehaviour
{
    [SerializeField]
    private int destreza;

    public void setDestreza(int valor)
    {
        if(valor >= 0)
        {
            destreza = valor;
        }

    }

    public int getDestreza()
    {
        return destreza;
    }
}