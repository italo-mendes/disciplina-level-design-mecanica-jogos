using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentarParaAlvo : MonoBehaviour
{
    public Transform alvo;
    private Velocidade velocidadeComponent;
    private Rigidbody rb;
    private Rigidbody2D rb2D;

    void Start()
    {
        if (!TryGetComponent<Velocidade>(out velocidadeComponent))
            print("Adicione o componente <color=orange>Velocidade</color> ao GameObject.");

        rb = GetComponent<Rigidbody>();
        rb2D = GetComponent<Rigidbody2D>();

        if (rb != null)
            StartCoroutine(MovimentaRigidbody());
        else if (rb2D != null)
            StartCoroutine(MovimentaRigidbody2D());
        else
            StartCoroutine(MovimentaTransform());
    }

    void LookAt2D()
    {
        Vector3 direcao = alvo.position - transform.position;
        direcao.Normalize();

        float rotacaoZ = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotacaoZ - 90);
    }

    IEnumerator MovimentaTransform()
    {
        while (true)
        {
            LookAt2D();

            transform.position = Vector3.MoveTowards(
                transform.position, alvo.position, 
                velocidadeComponent.GetVelocidade() * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator MovimentaRigidbody()
    {
        while (true)
        {
            LookAt2D();

            rb.MovePosition(transform.position + velocidadeComponent.GetVelocidade()
                    * Time.deltaTime * (alvo.position - transform.position));

            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator MovimentaRigidbody2D()
    {
        while (true)
        {
            LookAt2D();

            rb2D.MovePosition(transform.position + velocidadeComponent.GetVelocidade()
                    * Time.deltaTime * (alvo.position - transform.position));

            yield return new WaitForEndOfFrame();
        }
    }
}
