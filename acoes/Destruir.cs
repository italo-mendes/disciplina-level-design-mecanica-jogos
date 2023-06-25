using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir : MonoBehaviour
{
    public float delay; // Tempo em segundos até a destruição ocorrer
    public bool autoDestruicao; // Indica se o GameObject se autodestrói
    public GameObject objetoParaDestruir; // Variável do tipo Object para armazenar o GameObject ou componente

    void Start()
    {
        if (autoDestruicao)
        {
            Destroy(gameObject, delay);
        }
        else
        {
            Destroy(objetoParaDestruir, delay);
        }
    }
}
