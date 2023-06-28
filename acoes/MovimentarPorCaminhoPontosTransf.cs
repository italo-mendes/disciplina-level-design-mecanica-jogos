using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentarPorCaminhoPontosTransf : MonoBehaviour
{
    public float velocidade;
    public List<Transform> pontosDoCaminho;
    public bool reinicia = false;

    private int indiceAtual = 0;
    private Transform alvoAtual;

    void Start()
    {
        alvoAtual = pontosDoCaminho[indiceAtual];
    }

    void Update()
    {
        // Verifica se o GameObject alcançou o ponto de destino
        if (transform.position == alvoAtual.position)
        {
            // Incrementa o índice para o próximo ponto no caminho
            indiceAtual++;

            // Verifica se chegou ao último ponto do caminho
            if (indiceAtual >= pontosDoCaminho.Count)
            {
                // Verifica se deve reiniciar o movimento
                if (reinicia)
                {
                    // Reinicia o índice para o primeiro ponto do caminho
                    indiceAtual = 0;
                }
                else
                {
                    // Para o movimento caso não reinicie
                    return;
                }
            }

            // Define o próximo alvo de movimento
            alvoAtual = pontosDoCaminho[indiceAtual];
        }

        // Movimenta o GameObject em direção ao alvo atual
        transform.position = Vector3.MoveTowards(transform.position, alvoAtual.position, velocidade * Time.deltaTime);

        // Rotaciona o GameObject para olhar na direção do movimento
        transform.LookAt(alvoAtual);
    }
}