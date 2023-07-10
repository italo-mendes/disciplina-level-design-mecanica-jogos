using UnityEngine;

public class MovimentarPorCaminhoPontosRigidbody : MonoBehaviour
{
    public float velocidade = 5f;
    public Transform[] pontosCaminho;
    public bool reinicia = false;

    private int indicePontoAtual = 0;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (pontosCaminho.Length == 0)
            return;

        Vector3 direcao = pontosCaminho[indicePontoAtual].position - transform.position;
        direcao.Normalize();

        rb.MovePosition(transform.position + direcao * velocidade * Time.fixedDeltaTime);

        if (Vector3.Distance(transform.position, pontosCaminho[indicePontoAtual].position) < 0.1f)
        {
            indicePontoAtual++;

            if (indicePontoAtual >= pontosCaminho.Length)
            {
                if (reinicia)
                {
                    indicePontoAtual = 0;
                }
                else
                {
                    rb.velocity = Vector3.zero;
                    return;
                }
            }
        }

       transform.LookAt(pontosCaminho[indicePontoAtual]);
    }
}