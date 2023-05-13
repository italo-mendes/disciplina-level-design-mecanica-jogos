using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cura : MonoBehaviour
{
    [SerializeField]
    private int cura;

    public int GetCura()
    {
        return cura;
    }
    
    public void SetCura(int valor)
    {
        if (valor >= 0)
            cura = valor;
    }
}
