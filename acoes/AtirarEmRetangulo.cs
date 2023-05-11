using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AtirarEmRetangulo : MonoBehaviour
{
    public GameObject projetil;
    public int qtdDeLinhas;
    public float tempoEntreDisparos;
    public float distanciaLinhaDeTiros;

    void Start()
    {
        StartCoroutine(AtirarRetangulos());
    }

    IEnumerator AtirarRetangulos()
    {
        while (true)
        {
           for(int i = -2; i < qtdDeLinhas; i++)
            {
                Instantiate(projetil, 
                    new Vector3(transform.position.x, transform.position.y * i * distanciaLinhaDeTiros, transform.position.z), 
                    transform.rotation);
            }

            yield return new WaitForSeconds(tempoEntreDisparos);
        }
    }
}
