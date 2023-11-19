using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class AdicionaJogadoresComJoystick : MonoBehaviour
{
    public GameObject cam;
    public GameObject jogador;
    public bool primeiroJogadorNoTeclado;
    public string controlSchemeDoJoystick;
    public string controlSchemeDoTeclado;

    // alternativamente pode-se acessar todos os gameObjects
    // dos jogadores por PlayerInput.all[i].gameObject
    private List<GameObject> jogadores = new List<GameObject>();

    private IDisposable qualquerBotaoEventListener;
    private IDisposable qualquerBotaoTecladoEventListener;

    void Start()
    {
        GameObject goTemp;

        if (primeiroJogadorNoTeclado)
            for (int i = 0; i < 1; i++)
                for (int j = 0; j < 1; j++)
                {
                    goTemp = Instantiate(jogador, new Vector3(10.0f * i, 20.0f * j, 0.0f), transform.rotation);
                    jogadores.Add(goTemp);
                }

        cam.transform.position = new Vector3(10.0f * 0, 7.5f, -17.0f);

        qualquerBotaoEventListener = InputSystem.onAnyButtonPress.Call(OnButtonPressed);
        qualquerBotaoTecladoEventListener = InputSystem.onAnyButtonPress.Call(OnButtonPressedTeclado);
    }

    void OnButtonPressed(InputControl inpCtrl)
    {
        bool controleJaUsado = false;

        if (inpCtrl.device.GetType() == typeof(Joystick))
        {
            for (int i = 0; i < PlayerInput.all.Count; i++)
            {
                if (PlayerInput.all[i].devices[0].deviceId == inpCtrl.device.deviceId)
                {
                    controleJaUsado = true;
                    break;
                }   
            }

            if (!controleJaUsado)
                CriaTabuleiro(inpCtrl.device.deviceId, controlSchemeDoJoystick);
        }
    }

    void OnButtonPressedTeclado(InputControl inpCtrl)
    {
        // apenas 1 jogador pode usar o teclado no novo InputSystem
        if (inpCtrl.device.GetType().ToString().Contains("Keyboard"))
        {
            CriaTabuleiro(inpCtrl.device.deviceId, controlSchemeDoTeclado);
            qualquerBotaoTecladoEventListener.Dispose();
        }
    }

    public void CriaTabuleiro(int joystickId, string controlScheme)
    {
        GameObject goTemp;

        int i = jogadores.Count;
        int j = 0;

        goTemp = Instantiate(jogador, new Vector3(10.0f * i, 20.0f * j, 0.0f), transform.rotation);
        jogadores.Add(goTemp);

        PlayerInput.all[i].SwitchCurrentControlScheme(controlScheme, InputSystem.GetDeviceById(joystickId));

        cam.transform.position = new Vector3((10.0f * i) / 2, 7.5f, -17.0f);
    }

    void OnDisable()
    {
        qualquerBotaoEventListener.Dispose();

        if (qualquerBotaoTecladoEventListener != null)
            qualquerBotaoTecladoEventListener.Dispose();
    }
}
