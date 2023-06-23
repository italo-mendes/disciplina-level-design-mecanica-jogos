using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvancoCurtoRigidbody2D : MonoBehaviour
{
    [SerializeField]
    private float distanciaDoAvanco;
    [SerializeField]
    private float velocidadeDoAvanco;

    private Vector3 eixosDeAvanco;

    [SerializeField]
    private bool avancarNoEixoX;
    [SerializeField]
    private bool avancarNoEixoY;
    [SerializeField]
    private bool avancarNoEixoZ;

    private Rigidbody2D rb2D;
    
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        StartCoroutine(Avancar());
    }

    IEnumerator Avancar()
    {
        float dist = distanciaDoAvanco;

        if (!avancarNoEixoX & !avancarNoEixoY & !avancarNoEixoZ)
        {
            print("Selecione ao menos um dos eixos para o qual o objeto avançará");
        }
        else
        {
            if (avancarNoEixoX)
            {
                eixosDeAvanco.x = 1.0f;
            }

            if (avancarNoEixoY)
            {
                eixosDeAvanco.y = 1.0f;
            }

            if (avancarNoEixoZ)
            {
                eixosDeAvanco.z = 1.0f;
            }

            while (dist > 0)
            {
                rb2D.MovePosition(transform.position + velocidadeDoAvanco
                    * Time.deltaTime * eixosDeAvanco);

                dist -= Time.deltaTime * velocidadeDoAvanco;
                yield return new WaitForSeconds(Time.deltaTime);
            }
        }
    }
}
