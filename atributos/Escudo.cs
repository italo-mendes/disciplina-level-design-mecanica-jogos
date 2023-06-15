using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    [SerializeField]
    private bool escudo;

    [SerializeField]
    private int tempoEscudo = 5;//representando os 5 segundos de duração do escudo


    public bool getEscudo()
    {
        return escudo;
    }

    public void setEscudo(bool temEscudo)
    {
        if (temEscudo == false)
        {
            temEscudo = true;
        }
    }

    public int getTempoEscudo()
    {
        return tempoEscudo;
    }

    public void tomarDano(bool temEscudo)
    {
        temEscudo = false;
    }

    public void setTempoEscudo(bool temEscudo)
    {
        while(temEscudo == true)
        {
            tempoEscudo -= 1;
            if(tempoEscudo == 0)
            {
                temEscudo = false;
            }
        }
    }
    
    void Update()
    {

    }
}
