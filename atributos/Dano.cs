using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dano : MonoBehaviour
{
    [SerializeField]
    private int Dano;

    public int getDano()
    {
        return Dano;
    }

    public void setDano(int Valor)
    {
        if (Valor >= 0)
            Dano = Valor;
    }
}
