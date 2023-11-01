using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AplicarForca2D : MonoBehaviour
{
    public float forca;
    public Vector3 direcao;
    private Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        AplicaForca();
    }

    public void AplicaForca()
    {
        rb2D.AddForce(direcao * forca);
    }
}
