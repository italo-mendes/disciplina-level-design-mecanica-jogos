using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dano : MonoBehaviour
{
    [SerializeField]
    private int dano;

    public int GetDano()
    {
        return dano;
    }
    
    public void SetDano(int valor)
    {
        if (valor >= 0)
            dano = valor;
    }
}
