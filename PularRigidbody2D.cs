using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Requisitamos o componente Rigidbody
[RequireComponent(typeof(Rigidbody2D))]
public class PularRigidbody2D : MonoBehaviour
{
    //Variável que controla a força do pulo
    public float jumpForce;

    //Variável que controla a massa/peso
    public float massa;

    //Acessamos o componente Rigidbody através dessa variável
    private Rigidbody2D rigidbody;


    //Variável de controle que nos diz se o personagem está ou não no chão
    private bool isGround = false;

    void Start()
    {
        //Assim que o script  é executado, obtemos o componente Rigidbody e atribuimos a nossa variável
        rigidbody = GetComponent<Rigidbody2D>();

        //Definimos o valor da massa via script
        rigidbody.mass = massa;
    }


    void Update()
    {
        //Verificamos se o usuário NÃO pressionou a tecla Space ou se não está no chão
        if (!Input.GetKeyDown(KeyCode.Space) || !isGround)
            return;

        //Adicionamos uma força ao Rigidbody
        rigidbody.AddForce(
            Vector3.up * jumpForce, //Para fazer o personagem pular, então multiplicamos (0, 1, 0) pelo valor do pulo
            ForceMode2D.Impulse // Ajustamos a força para o tipo Impulse
            );
    }

    //Verifica se o personagem tocou no chão
    void OnCollisionEnter(Collision collision)
    {
        isGround = true;
    }

    //Verifica se o personagem saiu do chão
    void OnCollisionExit(Collision collision)
    {
        isGround = false;
    }
}