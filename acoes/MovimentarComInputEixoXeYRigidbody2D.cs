using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentarComInputEixoXeYRigidbody2D : MonoBehaviour
{
    public bool viraSprite;
    public Vector2 entrada;
    public float limiteXMinimo;
    public float limiteXMaximo;
    public float limiteYMinimo;
    public float limiteYMaximo;
    private Velocidade velocidadeComponent;
    private SpriteRenderer sr;
    private Animator animator;
    public string nomeParametroVelocidade;
    private Rigidbody2D rb2D;
    private PlayerInput pi;
    private Vector3 posTemp;

    void Start()
    {
        if (!TryGetComponent<Velocidade>(out velocidadeComponent))
            print("Adicione o componente <color=orange>Velocidade</color> ao GameObject.");

        sr = GetComponent<SpriteRenderer>();
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

        if (sr != null && viraSprite)
            if (entrada.x < 0)
                sr.flipX = true;
            else if (entrada.x > 0)
                sr.flipX = false;
    }

    void FixedUpdate()
    {
        posTemp = transform.position + velocidadeComponent.GetVelocidade()
            * Time.fixedDeltaTime * new Vector3(entrada.x, entrada.y, 0.0f);

        if (posTemp.x > limiteXMinimo && posTemp.x < limiteXMaximo &&
            posTemp.y > limiteYMinimo && posTemp.y < limiteYMaximo)
                rb2D.MovePosition(posTemp);
    }

    IEnumerator ObtemEntradaEixos()
    {
        while(true) 
        {
            entrada.x = Input.GetAxisRaw("Horizontal");
            entrada.y = Input.GetAxisRaw("Vertical");

            if (animator != null)
                animator.SetFloat(nomeParametroVelocidade, Mathf.Abs(entrada.x));

            if (sr != null && viraSprite)
                if (entrada.x < 0)
                    sr.flipX = true;
                else if (entrada.x > 0)
                    sr.flipX = false;

            yield return new WaitForEndOfFrame();
        }
    }
}
