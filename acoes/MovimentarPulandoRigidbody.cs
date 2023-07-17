using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentarPulandoRigidbody : MonoBehaviour
{
    public Velocidade velocidadeComponente;
    public string tagDoObjetoDeSalto;
    public float forcaDoPulo;


    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (!TryGetComponent<Velocidade>(out velocidadeComponente))
            print("Adicione o componente <color=orange>Velocidade</color> ao GameObject.");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tagDoObjetoDeSalto))
        {
            rb.AddForce(Vector3.up * forcaDoPulo, ForceMode.Impulse);
        }
    }

}
