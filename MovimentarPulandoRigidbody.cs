using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentarPulandoRigidbody : MonoBehaviour
{
    public float velocidade;
    public string tagDoObjetoDeSalto;
    public float forcaDoPulo;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Movimentar para frente
        Vector3 movimento = transform.forward * velocidade * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movimento);

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

