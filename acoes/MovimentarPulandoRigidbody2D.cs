using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentarPulandoRigidbody2D : MonoBehaviour
{
    public Velocidade velocidadeComponente;


    public string tagPula;
    public float forcaPulo;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (!TryGetComponent<Velocidade>(out velocidadeComponente))
            print("Adicione o componente <color=orange>Velocidade</color> ao GameObject.");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagPula))
        {
            rb.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
        }
    }
}