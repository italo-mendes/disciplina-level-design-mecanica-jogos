using UnityEngine;
using System.Collections.Generic;

public class MovimentarPorCaminhoPontosRigidbody2D : MonoBehaviour
{
    public Transform objeto;
    private Velocidade velocidade;
    public List<Transform> objetos;
    private Rigidbody2D rb;
    private int i;
    public bool reinicia;
    private bool ida;
    private float speedY;
    private Vector2 lastPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        objeto = objetos[i];
        i = 0;
        ida = true;
        if (!TryGetComponent<Velocidade>(out velocidade))
            print("Adicione o componente <color=orange>Velocidade</color> ao GameObject.");

    }

    private void Moviment()
    {
        // Calcula a direção do objetoB em relação ao objetoA
        if(objeto){
            Vector2 direcao = (objeto.position - transform.position).normalized;
            rb.MovePosition(rb.position + direcao * velocidade * Time.fixedDeltaTime);

            // Calcula a direção do movimento
            Vector2 movementDirection = rb.position.normalized;

            if(objeto.position.x > gameObject.transform.position.x){
                transform.eulerAngles = new Vector3(0f,180f,0f);
            }
            if(objeto.position.x < gameObject.transform.position.x){
                transform.eulerAngles = new Vector3(0f,0,0f);
            }
        }
    }

    private void FixedUpdate()
    {
        Moviment();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Ponto"){
            if(ida){
                if(i+1<objetos.Count){
                    objeto = objetos[++i];
                }
                else{
                    if(reinicia){
                        ida = false;
                    }
                    else{
                        objeto = null;
                    }
                }
            }
            if(!ida){
                if(i-1>=0){
                    objeto = objetos[--i];
                }
                else{
                    objeto = null;
                }
            }
        }
    }
}