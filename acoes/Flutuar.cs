using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flutuar : MonoBehaviour
{
    //Graus de rotação por segundo
    public float grausPorSegundo = 20.0f;

    //Amplitude de elevação do objeto flutuando
    public float amplitude = 0.25f;

    //Frequência de "Elevações" do objeto
    public float frequencia = 1f;

    void Update()
    {
        // Gira o objeto em torno do eixo Y. Caso seja 3D, substituir Vector2(...) por Vector3(...), e adicionar '0f' como terceiro argumento
        transform.Rotate(new Vector3(0.0f, Time.deltaTime * grausPorSegundo, 0.0f), Space.World);

        // Flutua o objeto para cima e para baixo com Mathf.Sin
        transform.position = new Vector3(0.0f, Mathf.Sin(Time.fixedTime * Mathf.PI * frequencia) * amplitude, 0.0f);
    }
}
