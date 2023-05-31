using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.PlayerSettings;

public class EntradaFloat : MonoBehaviour
{
    public float entrada;

    public void ObtemEntrada(InputAction.CallbackContext contexto)
    {
        entrada = contexto.ReadValue<float>();
    }

    public float GetEntrada()
    {
        return entrada;
    }
}
