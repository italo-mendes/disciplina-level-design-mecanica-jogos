using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.PlayerSettings;

public class EntradaVetor2D : MonoBehaviour
{
    public Vector2 entrada;

    public void ObtemEntrada(InputAction.CallbackContext contexto)
    {
        entrada = contexto.ReadValue<Vector2>();
    }

    public Vector2 GetEntrada()
    {
        return entrada;
    }
}
