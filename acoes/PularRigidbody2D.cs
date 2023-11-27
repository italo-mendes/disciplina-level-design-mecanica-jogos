using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    private Rigidbody2D rb2D;
    private int pulos;
    private RigidbodyConstraints constraintsOriginais;
    private Quaternion rotacaoOriginal;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void ObtemEntrada(InputAction.CallbackContext contexto)
    {
        if (contexto.started)
            Pular();
    }

    public void Pular()
    {
        if (forcaDoPulo == 0.0f)
        {
            return;
        }

        if (temPuloDuplo && pulos < 2 || !temPuloDuplo && pulos == 0)
        {

            pulos++;
            rb2D.AddForce(forcaDoPulo * rb2D.transform.up * Time.deltaTime, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (pulos != 0)
        {
            pulos = 0;
        }
    }
}
