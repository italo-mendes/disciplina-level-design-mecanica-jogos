using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    [SerializeField]
    private int mana;
    [SerializeField]
    private int manaMaximo; 

    public void setManaMaximo(int valor)
    {
        if(valor > 0)
        {
            manaMaximo = valor;
        }
    }

    public int getManaMaximo()
    {
        return manaMaximo;
    }

    public void setMana(int valor)
    {
        if (manaMaximo > 0)
        {
            if (valor >= 0 && valor <= manaMaximo)
            {
                manaMaximo = valor;
            }
        }
        else
        {
            if (valor >= 0)
            {
                manaMaximo = valor;
            }
        }
    }
    public int getMana()
    {
        return manaMaximo;
    }
}
