using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentarParaAlvoRigidbody : MonoBehaviour
{
    private Velocidade velocidadeComponent;
    public Rigidbody rb;
    public Transform transform;

    void Start()
    {
        if (!TryGetComponent<Velocidade>(out velocidadeComponent))
            print("Adicione o componente <color=orange>Velocidade</color> ao GameObject.");
        
        rb = GetComponent<Rigidbody>();
        
    }

    void FixedUpdate()
    {
        transform.LookAt(transform);
        rb.MovePosition(velocidadeComponent.GetVelocidade() 
            * Time.fixedDeltaTime * transform.forward + rb.position);
    }
}
