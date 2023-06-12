using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirDepeoisDelay : MonoBehaviour
{
    public float delay = 2f; // Tempo em segundos até a destruição ocorrer
    public bool autoDestruicao = false; // Indica se o GameObject se autodestrói
    public Object objetoParaDestruir; // Variável do tipo Object para armazenar o GameObject ou componente

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
