using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentarParaFrenteAleatorioRigidbody : MonoBehaviour
{
    [SerializeField]
    private Velocidade velocidade;
    [SerializeField]
    private float tempoDeMovimentacao;
    [SerializeField]
    private float anguloMin;
    [SerializeField]
    private float anguloMax;

    private Rigidbody rb;
    private bool movendo;

    void Start()
    {
        if (!TryGetComponent<Velocidade>(out velocidade))
            print("Adicione o componente <color=orange>Velocidade</color> ao GameObject.");
        rb = GetComponent<Rigidbody>();
        movendo = false;
        
        StartCoroutine(Movimentar());
    }

    void FixedUpdate()
    {
        if (movendo)
        {
            rb.MovePosition(
                velocidade.GetVelocidade() * Time.fixedDeltaTime
                * transform.forward + rb.position);
        }
        else
        {
            float angulo = Random.Range(anguloMin, anguloMax);
            rb.MoveRotation(Quaternion.Euler(0.0f, angulo, 0.0f) * rb.rotation);
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
