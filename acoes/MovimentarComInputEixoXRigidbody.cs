using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentarComInputEixoXRigidbody : MonoBehaviour
{
    public Vector2 entrada;
    private Velocidade velocidadeComponent;
    private Animator animator;
    public string nomeParametroVelocidade;
    private Rigidbody rb;

    void Start()
    {
        if (!TryGetComponent<Velocidade>(out velocidadeComponent))
            print("Adicione o componente <color=orange>Velocidade</color> ao GameObject.");

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    public void ObtemEntrada(InputAction.CallbackContext contexto)
    {
        entrada = contexto.ReadValue<Vector2>();

        if (animator != null)
            animator.SetFloat(nomeParametroVelocidade, Mathf.Abs(entrada.x));

        if (entrada.x < 0)
            transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        else if (entrada.x > 0)
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + velocidadeComponent.GetVelocidade()
            * Mathf.Abs(entrada.x) * Time.fixedDeltaTime * transform.right);
    }
}
