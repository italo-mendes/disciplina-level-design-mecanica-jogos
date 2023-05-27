using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentarParaFrenteAleatorioRigidbody2D : MonoBehaviour
{
    [SerializeField]
    private float velocidade;
    [SerializeField]
    private float tempoDeMovimentacao;
    [SerializeField]
    private float anguloMin;
    [SerializeField]
    private float anguloMax;

    private Rigidbody2D rb;
    private bool movendo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movendo = false;

        StartCoroutine(Movimentar());
    }

    void FixedUpdate()
    {
        if (movendo)
        {
            rb.MovePosition(velocidade * Time.fixedDeltaTime * (Vector2) transform.right + rb.position);
        }
        else
        {
            float angulo = Random.Range(anguloMin, anguloMax);
            rb.MoveRotation(rb.rotation + angulo);
        }
    }

    IEnumerator Movimentar()
    {
        while (true)
        {
            movendo = true;
            yield return new WaitForSeconds(tempoDeMovimentacao);
            movendo = false;
            yield return new WaitForFixedUpdate();
        }
    }
}
