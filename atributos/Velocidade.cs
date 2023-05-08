using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Velocidade : MonoBehaviour
{
    [SerializeField]
    private float velocidade;
    [SerializeField]
    private float velocidadeMaxima;

    public float GetVelocidade()
    {
        return velocidade;
    }

    public void SetVelocidade(float valor)
    {
        if (velocidadeMaxima > 0.0f)
            if (valor <= velocidadeMaxima)
                velocidade = valor;
        else
            velocidade = valor;
    }

    public float GetVelocidadeMaxima()
    {
        return velocidadeMaxima;
    }

    public void SetVelocidadeMaxima(int valor)
    {
        velocidadeMaxima = valor;
    }
}
