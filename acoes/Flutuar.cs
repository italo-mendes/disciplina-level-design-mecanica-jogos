using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flutuar : MonoBehaviour
{
    //Graus de rota��o por segundo
    public float grausPorSegundo = 20.0f;

    //Amplitude de eleva��o do objeto flutuando
    public float amplitude = 0.25f;

    //Frequ�ncia de "Eleva��es" do objeto
    public float frequencia = 1f;

    //Vari�veis que armazenam a posi��o do objeto. Caso seja 3D, substituir Vector2() por Vector3()
    Vector2 posOffset = new Vector2();
    Vector2 tempPos = new Vector2();

    void Start()
    {
        // Armazena a posi��o inicial e a rota��o inicial do objeto
        posOffset = transform.position;
    }

    void Update()
    {
        // Gira o objeto em torno do eixo Y. Caso seja 3D, substituir Vector2(...) por Vector3(...), e adicionar '0f' como terceiro argumento
        transform.Rotate(new Vector2(0f, Time.deltaTime * grausPorSegundo), Space.World);

        // Flutua o objeto para cima e para baixo com Mathf.Sin
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequencia) * amplitude;

        transform.position = tempPos;
    }
}
