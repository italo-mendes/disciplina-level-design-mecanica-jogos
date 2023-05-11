using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResistenciaMagica : MonoBehaviour
{
    public int resistenciaMagica;
    
    public int GetResistenciaMagica()
    {
        return resistenciaMagica;
    }

    public void SetResistenciaMagica(int valor1)
    {
        if (valor1 >= 0)
            resistenciaMagica = valor1;
        else
            resistenciaMagica = (valor1)*(-1);
    }
}


