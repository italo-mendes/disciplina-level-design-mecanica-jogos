using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Vida : MonoBehaviour
{
    [SerializeField]
    private int vida;

    // se VidaMaxima for zero, então o gameObject não terá vidaMaxima
    [SerializeField]
    private int vidaMaxima;

    public bool semVidaSeDestroi;
    public float tempoAntesDestruicao;
    public int pontuacao;
    public UnityEvent eventosAntesDestruicao;
    public UnityEvent eventosReducaoVida;

    public int GetVida()
    {
        return vida;
    }

    public void SetVida(int valor)
    {
        if (valor >= 0)
            if (vidaMaxima > 0)
            {
                if (valor > vidaMaxima)
                    vida = vidaMaxima;
                else
                    vida = valor;
            }
            else
            {
                vida = valor;
            }
        else
            vida = 0;

        
        if (vida <= 0)
        {
            eventosAntesDestruicao.Invoke();

            if (pontuacao > 0 && GameManager.gm != null)
                GameManager.gm.GetComponent<GameManager>().VariacaoPontuacao(pontuacao);

            if (semVidaSeDestroi)
                Destroy(gameObject, tempoAntesDestruicao);
        }
    }

    public void VariacaoVida(int variacao)
    {
        vida += variacao;

        if (vida > vidaMaxima)
            vida = vidaMaxima;

        if (variacao < 0)
            eventosReducaoVida.Invoke();
    }

    public int GetVidaMaxima()
    {
        return vidaMaxima;
    }

    public void SetVidaMaxima(int valor)
    {
        vidaMaxima = valor;
    }
}
