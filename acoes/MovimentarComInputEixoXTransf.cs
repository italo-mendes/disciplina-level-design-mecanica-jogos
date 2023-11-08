using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentarComInputEixoXTransf : MonoBehaviour
{
    public bool viraSprite;
    public Vector2 entrada;
    private Velocidade velocidadeComponent;
    private SpriteRenderer sr;
    private Animator animator;
    public string nomeParametroVelocidade;
    private PlayerInput pi;

    void Start()
    {
        if (!TryGetComponent<Velocidade>(out velocidadeComponent))
            print("Adicione o componente <color=orange>Velocidade</color> ao GameObject.");

        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
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

    void Update()
    {
        transform.Translate(velocidadeComponent.GetVelocidade()
            * entrada.x * Time.deltaTime * transform.right);
    }

    IEnumerator ObtemEntradaEixos()
    {
        while (true)
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
