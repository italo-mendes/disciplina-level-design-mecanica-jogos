using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class EntradaPressionaBotao : MonoBehaviour
{
    public UnityEvent metodos;

    public void ObtemEntrada(InputAction.CallbackContext contexto)
    {
        // started (begin pressed), performed (pressed), canceled (released)
        if (contexto.started)
            metodos.Invoke();
    }
}
