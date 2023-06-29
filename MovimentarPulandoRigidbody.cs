using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentarPulandoRigidbody : MonoBehaviour
{
    public Velocidade velocidade;
    public string tagDoObjetoDeSalto;
    public float forcaDoPulo;
    public MovimentarParaFrenteRigidbody movimentarParaFrenteRigidbody;

    private Rigidbody rb;

    private void start()
    {
        rb = GetComponent<Rigidbody>();
        if (!TryGetComponent<Velocidade>(out velocidade))
            print("Adicione o componente <color=orange>Velocidade</color> ao GameObject.");
        
        if (!TryGetComponent<MovimentarParaFrenteRigidbody>(out movimentarParaFrenteRigidbody))
            print("Adicione o componente <color=orange>MovimentarParaFrenteRigidbody</color> ao GameObject.");
    }

    private void FixedUpdate()
    {
        // Movimentar para frente
        movimentarParaFrenteRigidbody.Start();
        
        //Vector3 movimento = transform.forward * velocidade.GetVelocidade() * Time.fixedDeltaTime;
        //rb.MovePosition(rb.position + movimento);

        // Verificar se esta colidindo com o objeto de salto
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.5f);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag(tagDoObjetoDeSalto))
            {
                // Pular
                rb.AddForce(Vector3.up * forcaDoPulo, ForceMode.Impulse);
                break;
            }
        }
    }
}