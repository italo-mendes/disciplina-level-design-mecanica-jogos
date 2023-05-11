using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destreza : MonoBehaviour
{   
    public int destreza;
    
    public int GetDestreza()
    {
        return destreza;
    }

    public void SetDestreza(int valor)
    {
        if (valor >= 0)
            destreza = valor;
        else
            destreza = (valor)*(-1);
    }
}
