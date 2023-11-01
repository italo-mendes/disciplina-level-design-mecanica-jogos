using System;
using System.Collections;
using UnityEngine;

public class AvancoCurtoRigidbody : MonoBehaviour
{
    public float distanciaDoAvanco;
    public float velocidadeDoAvanco;
    public Vector3 direcaoDeAvanco;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        StartCoroutine(Avancar());
    }

    public IEnumerator Avancar()
    {
        float dist = distanciaDoAvanco;

        while (dist > 0)
        {
            rb.MovePosition(transform.position + velocidadeDoAvanco
                * Time.deltaTime * direcaoDeAvanco);

            dist -= Time.deltaTime * velocidadeDoAvanco;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
