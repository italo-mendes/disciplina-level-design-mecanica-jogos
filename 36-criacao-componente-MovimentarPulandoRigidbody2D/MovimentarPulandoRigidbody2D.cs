using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentarPulandoRigidbody2D : MonoBehaviour
{
    public string tagPula;
    public float forcaPulo;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tagPula))
        {
             rb.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
        }
    }
}
