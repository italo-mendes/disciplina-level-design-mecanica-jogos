using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentarComInputEixoXeYRotacaoRigidbody2D : MonoBehaviour
{
    public Vector2 entrada;
    public float velocidadeRotacao;
    public float limiteXMinimo;
    public float limiteXMaximo;
    public float limiteYMinimo;
    public float limiteYMaximo;
    private Velocidade velocidadeComponent;
    private Animator animator;
    public string nomeParametroVelocidade;
    private Rigidbody2D rb2D;
    private PlayerInput pi;
    private Vector3 posTemp;

    void Start()
    {
        if (!TryGetComponent<Velocidade>(out velocidadeComponent))
            print("Adicione o componente <color=orange>Velocidade</color> ao GameObject.");

        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
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
            * Time.fixedDeltaTime * entrada.y * transform.up;

        if (posTemp.x > limiteXMinimo && posTemp.x < limiteXMaximo &&
            posTemp.y > limiteYMinimo && posTemp.y < limiteYMaximo)
                rb2D.MovePosition(posTemp);

        transform.Rotate(0.0f, 0.0f, entrada.x * Time.fixedDeltaTime * -velocidadeRotacao);
    }

    IEnumerator ObtemEntradaEixos()
    {
        while (true)
        {
            entrada.x = Input.GetAxisRaw("Horizontal");
            entrada.y = Input.GetAxisRaw("Vertical");

            yield return new WaitForEndOfFrame();
        }
    }
}
