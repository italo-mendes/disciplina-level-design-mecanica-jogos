using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class EntradaSoltaBotao : MonoBehaviour
{
    public UnityEvent metodos;

    public void ObtemEntrada(InputAction.CallbackContext contexto)
    {
        if (contexto.canceled)
            metodos.Invoke();
    }
}
