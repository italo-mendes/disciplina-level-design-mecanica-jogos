using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armadura : MonoBehaviour
{
    [SerializeField]
    private int armadura;

    public int GetArmadura()
    {
        return armadura;
    }

    public void SetArmadura(int valor)
    {
        armadura = Mathf.Max(valor, 0);
    }
    // mathf.max garante que o valor nunca será menor que 0
}