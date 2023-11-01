using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvancoCurtoRigidbody2D : MonoBehaviour
{
    public float distanciaDoAvanco;
    public float velocidadeDoAvanco;
    public Vector3 direcaoDeAvanco;

    private Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        StartCoroutine(Avancar());
    }

    public IEnumerator Avancar()
    {
        float dist = distanciaDoAvanco;

        while (dist > 0)
        {
            rb2D.MovePosition(transform.position + velocidadeDoAvanco
                * Time.deltaTime * direcaoDeAvanco);

            dist -= Time.deltaTime * velocidadeDoAvanco;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
