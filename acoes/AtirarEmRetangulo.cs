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
            int i = qtdDeLinhas / 2;
            float metadeDaDistancia = distanciaLinhaDeTiros / 2;
            if (qtdDeLinhas % 2 == 0)
                for (int j = -i; j < i; j++)
                {
                    Instantiate(projetil,
                        new Vector3(transform.position.x, 
                            transform.position.y + (j * distanciaLinhaDeTiros) + metadeDaDistancia, 
                            transform.position.z),
                            transform.rotation
                        );
                }
            else
                for (int j = -i; j <= i; j++)
                {
                    Instantiate(projetil,
                        new Vector3(transform.position.x,
                            transform.position.y + j * distanciaLinhaDeTiros,
                            transform.position.z),
                            transform.rotation
                        );
                }



            yield return new WaitForSeconds(tempoEntreDisparos);
        }
    }

}
