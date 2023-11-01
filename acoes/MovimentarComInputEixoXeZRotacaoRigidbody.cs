using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentarComInputEixoXeZRotacaoRigidbody : MonoBehaviour
{
    public Vector2 entrada;
    public float velocidadeRotacao;
    public float limiteXMinimo;
    public float limiteXMaximo;
    public float limiteZMinimo;
    public float limiteZMaximo;
    private Velocidade velocidadeComponent;
    private Animator animator;
    public string nomeParametroVelocidade;
    private Rigidbody rb;
    private PlayerInput pi;
    private Vector3 posTemp;

    void Start()
    {
        if (!TryGetComponent<Velocidade>(out velocidadeComponent))
            print("Adicione o componente <color=orange>Velocidade</color> ao GameObject.");

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        pi = GetComponent<PlayerInput>();

        if (pi == null)
            StartCoroutine(ObtemEntradaEixos());
    }

    public void ObtemEntrada(InputAction.CallbackContext contexto)
    {
        entrada = contexto.ReadValue<Vector2>();

        if (animator != null)
            animator.SetFloat(nomeParametroVelocidade, Mathf.Abs(entrada.x));
    }

    void FixedUpdate()
    {
        posTemp = transform.position + velocidadeComponent.GetVelocidade()
            * Time.fixedDeltaTime * entrada.y * transform.forward;

        if (posTemp.x > limiteXMinimo && posTemp.x < limiteXMaximo &&
            posTemp.z > limiteZMinimo && posTemp.z < limiteZMaximo)
            rb.MovePosition(posTemp);

        transform.Rotate(0.0f, entrada.x * Time.fixedDeltaTime * -velocidadeRotacao, 0.0f);
    }

    IEnumerator ObtemEntradaEixos()
    {
        while (true)
        {
            entrada.x = Input.GetAxisRaw("Horizontal");
            entrada.y = Input.GetAxisRaw("Vertical");

            if (animator != null)
                animator.SetFloat(nomeParametroVelocidade, Mathf.Abs(entrada.x));

            yield return new WaitForEndOfFrame();
        }
    }
}
