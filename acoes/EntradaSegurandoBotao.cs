using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class EntradaSegurandoBotao : MonoBehaviour
{
    public UnityEvent metodos;
    private IEnumerator coroutine;

    void Start()
    {
        coroutine = VerificaSoltarBotao();
    }

    public void ObtemEntrada(InputAction.CallbackContext contexto)
    {
        if (contexto.performed)
            StartCoroutine(coroutine);

        if (contexto.canceled)
            StopCoroutine(coroutine);
    }

    IEnumerator VerificaSoltarBotao()
    {
        while(true)
        {
            metodos.Invoke();

            yield return new WaitForEndOfFrame();
        }
    }
}
