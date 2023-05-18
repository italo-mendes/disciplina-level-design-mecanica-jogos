using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExemplosAula : MonoBehaviour
{
    public float velocidade;
    public Transform porta;

    void Start()
    {
        print(transform.parent.name);
    }

    void Update()
    {
        /*
        É obrigatório uso do Time.deltaTime para
        evitar que em computadores que executem o
        jogo com FPS (Frames Por Segundo) diferentes
        causem diferentes resultados no jogo

        Considere a movimentação de um GameObject
        usando velocidade = 5 e a função Translate()

        transform.Translate(velocidade * new Vector3(1.0f, 0.0f, 0.0f));

        Em cada vez que a função Translate() é chamada,
        ou seja, em cada frame, o GameObject se
        deslocará 5 unidades na direção do eixo X pois

        5 * (1.0f, 0.0f, 0.0f) = (5.0f, 0.0f, 0.0f)

        Em computadores que executem o jogo a 40 FPS
        e 200 FPS, o GameObject se deslocará em cada segundo

        40 FPS  =====> 40 * 5 = 200 unidades
        200 FPS =====> 200 * 5 = 1000 unidades

        Ou seja, em cada segundo em um computador o
        GameObject se deslocará 200 unidades e no
        outro computador 1000 unidades, sendo um
        jogo de corrida por exemplo, um jogador
        teria mais vantagem que o outro.

        A fim de evitar a diferença entre os jogadores
        deve-se usar o comando Time.deltaTime que retorna
        o intervalo de tempo entre a geração de cada frame
        do jogo. Igualando assim os valores usados para
        animações em computador com FPS diferentes

        Então usando Time.deltaTime no deslocamento e
        lembrando que 1 seg = 1000 milisegundos (ms)

        40 FPS -------------
        1000 / 40 = 25 ms  (intervalo de tempo entre frames, ou seja, Time.deltaTime)

        25 / 1000 = 0.025 seg (convertendo para segundos)

        40 * 5 * 0.025 = 5 unidades

    
        200 FPS -------------
        1000 / 200 = 5 ms  (intervalo de tempo entre frames, ou seja, Time.deltaTime)
        
        5 / 1000 = 0.005 seg  (convertendo para segundos)

        200 * 5 * 0.005 = 5 unidades


        Assim, observa-se que usando Time.deltaTime, independente
        do FPS que o jogo execute, o GameObject se deslocará na
        mesma quantidade (5 unidades) em computadores diferentes
        */

        // deslocamento genérico
        /*
        transform.Translate(
            velocidade * Time.deltaTime 
            * new Vector3(1.0f, 0.0f, 0.0f)
        );
        */

        // deslocamento eixos globais
        // x --> Vector3.right
        // y --> Vector3.up
        // z --> Vector3.forward
        /*
        transform.Translate(
            velocidade * Time.deltaTime 
            * Vector3.right
        );
        */

        // deslocamento eixos locais (do gameObject)
        // x --> transform.right
        // y --> transform.up
        // z --> transform.forward
        /*
        transform.Translate(
            velocidade * Time.deltaTime 
            * transform.right
        );
        */

        // rotacionar um gameObject
        /*
        transform.Rotate(
            velocidade * Time.deltaTime
            * new Vector3(1.0f, 0.0f, 0.0f)
        );
        */
    }

}
