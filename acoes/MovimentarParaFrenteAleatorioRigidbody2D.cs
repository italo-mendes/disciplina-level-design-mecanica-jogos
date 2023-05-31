using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentarParaFrenteAleatorioRigidbody2D : MonoBehaviour
{
    [SerializeField]
    private Velocidade velocidade;
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
        if (!TryGetComponent<Velocidade>(out velocidade))
            print("Adicione o componente <color=orange>Velocidade</color> ao GameObject.");
        rb = GetComponent<Rigidbody2D>();
        movendo = false;

        StartCoroutine(Movimentar());
    }

    void FixedUpdate()
    {
        if (movendo)
        {
            rb.MovePosition(
                velocidade.GetVelocidade() * Time.fixedDeltaTime
                * (Vector2)transform.right + rb.position);
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
