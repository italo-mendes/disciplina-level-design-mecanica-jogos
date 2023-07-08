using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResistenciaMagica : MonoBehaviour
{
    [SerializeField]
    private int resistenciaMagica;

    public int GetResistenciaMagica()
    {
        return resistenciaMagica;
    }

    public void SetResistenciaMagica(int valor)
    {
        resistenciaMagica = Mathf.Max(valor, 0);
    }
    // mathf.max - garante que o valor nunca sera menor que 0
}