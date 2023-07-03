using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentarPulandoRigidbody : MonoBehaviour
{
    public string tagDoObjetoDeSalto;
    public float forcaDoPulo;


    private Rigidbody rb;

    void start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tagDoObjetoDeSalto)){
            rb.AddForce(Vector3.up * forcaDoPulo, ForceMode.Impulse);
        }
    }

}