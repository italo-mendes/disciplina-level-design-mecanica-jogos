using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PularRigidbody : MonoBehaviour
{
    [SerializeField]
    private float forcaDoPulo;
    [SerializeField]
    private bool temPuloDuplo;
    [SerializeField]
    private bool podeAvancarNoPulo;
    [SerializeField]
    private bool podeDirecionarDuranteOPulo;

    private Rigidbody rb;
    private int pulos;
    private RigidbodyConstraints constraintsOriginais;
    private Quaternion rotacaoOriginal;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Bloqueia a rotação nos eixos globais
        if (pulos != 0 && !podeDirecionarDuranteOPulo)
        {
            rb.rotation = rotacaoOriginal;
        }
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
                // Bloqueia a movimentação nos eixos X e Z
                rb.constraints |= RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            }

            if (!podeDirecionarDuranteOPulo)
            {
                rotacaoOriginal = rb.rotation;

                // Bloqueia a rotação nos eixos locais
                rb.constraints |= RigidbodyConstraints.FreezeRotation;
            }

            pulos++;
            rb.AddForce(forcaDoPulo * rb.transform.up * Time.deltaTime, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
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
