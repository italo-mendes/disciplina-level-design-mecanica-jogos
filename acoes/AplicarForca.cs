using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AplicarForca : MonoBehaviour
{
    public float forca;
    public Vector3 direcao;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        AplicaForca();
    }

    public void AplicaForca()
    {
        rb.AddForce(direcao * forca);
    }
}
