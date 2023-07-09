using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PularRigidbody2D : MonoBehaviour
{
    [SerializeField]
    private float forcaDoPulo;
    [SerializeField]
    private bool temPuloDuplo;
    [SerializeField]
    private bool podeAvancarNoPulo;
    [SerializeField]
    private bool podeDirecionarDuranteOPulo;

    private Rigidbody2D rb;
    private int pulos;
    private RigidbodyConstraints2D constraintsOriginais;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Pular()
    {
        if (forcaDoPulo == 0.0f)
        {
            return;
        }

        if (temPuloDuplo && pulos < 2 || !temPuloDuplo && pulos == 0)
        {
            if (!(podeAvancarNoPulo && podeDirecionarDuranteOPulo) && pulos == 0)
            {
                constraintsOriginais = rb.constraints;
            }

            if (!podeAvancarNoPulo)
            {
                rb.constraints |= RigidbodyConstraints2D.FreezePositionX;
            }

            if (!podeDirecionarDuranteOPulo)
            {
                rb.constraints |= RigidbodyConstraints2D.FreezeRotation;
            }

            pulos++;
            rb.AddForce(forcaDoPulo * Time.deltaTime * (Vector2) rb.transform.up, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (pulos != 0)
        {
            pulos = 0;

            if (!(podeAvancarNoPulo && podeDirecionarDuranteOPulo))
            {
                rb.constraints = constraintsOriginais;
            }
        }
    }
}
