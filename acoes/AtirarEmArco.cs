using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtirarEmArco : MonoBehaviour
{
    public GameObject projetil;
    public int numeroDirecoes;
    public float tempoEntreDisparos;
    private int angulo;
    private Quaternion rotacaoInicial;

    void Start()
    {
        angulo = 180 / numeroDirecoes;
        rotacaoInicial = transform.localRotation;
        
        StartCoroutine(Atira());
    }
    
    IEnumerator Atira()
    {
        while (true)
        {
            // 90, pois é a metade de 180 graus
            transform.Rotate(0.0f, -(90 - (angulo / 2)), 0.0f, Space.Self);
            Instantiate(projetil, transform.position, transform.rotation);

            // for (int i = 2; i <= numeroDirecoes; i++)
            // OU
            for (int i = 1; i <= numeroDirecoes - 1; i++)
            {
                transform.Rotate(0.0f, angulo, 0.0f, Space.Self);
                Instantiate(projetil, transform.position, transform.rotation);
            }

            transform.localRotation = rotacaoInicial;

            yield return new WaitForSeconds(tempoEntreDisparos);
        }
    }
}
