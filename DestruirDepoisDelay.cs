using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirDepeoisDelay : MonoBehaviour
{
    public float delay = 2f; // Tempo em segundos at� a destrui��o ocorrer
    public bool autoDestruicao = false; // Indica se o GameObject se autodestr�i
    public Object objetoParaDestruir; // Vari�vel do tipo Object para armazenar o GameObject ou componente

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
