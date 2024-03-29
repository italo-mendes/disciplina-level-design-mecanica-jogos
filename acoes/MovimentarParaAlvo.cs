using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentarParaAlvo : MonoBehaviour
{
    public Transform alvo;
    public float distanciaDeParada;
    private Velocidade velocidadeComponent;
    private Rigidbody rb;

    void Start()
    {
        if (!TryGetComponent<Velocidade>(out velocidadeComponent))
            print("Adicione o componente <color=orange>Velocidade</color> ao GameObject.");

        rb = GetComponent<Rigidbody>();

        if (rb != null)
            StartCoroutine(MovimentaRigidbody());
        else
            StartCoroutine(MovimentaTransform());
    }

    IEnumerator MovimentaTransform()
    {
        while (true)
        {
            transform.LookAt(alvo);

            transform.position = Vector3.MoveTowards(
                transform.position, alvo.position, 
                velocidadeComponent.GetVelocidade() * Time.deltaTime);

            if (Vector3.Distance(transform.position, alvo.position) <= distanciaDeParada)
                yield break;

            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator MovimentaRigidbody()
    {
        while (true)
        {
            transform.LookAt(alvo);

            rb.MovePosition(transform.position + velocidadeComponent.GetVelocidade()
                    * Time.deltaTime * (alvo.position - transform.position));

            if (Vector3.Distance(transform.position, alvo.position) <= distanciaDeParada)
                yield break;

            yield return new WaitForEndOfFrame();
        }
    }
}
