using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PularRigidbody2D : MonoBehaviour
{
    public float forcaDoPulo;
    public int pulos;
    public string tagResetaPulos;
    [SerializeField]
    private bool temPuloDuplo;
    [SerializeField]
    private bool podeAvancarNoPulo;
    [SerializeField]
    private bool podeDirecionarDuranteOPulo;

    private Rigidbody2D rb2D;
    private int pulosValorInicial;
    private RigidbodyConstraints constraintsOriginais;
    private Quaternion rotacaoOriginal;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        pulosValorInicial = pulos;
    }

    public void ObtemEntrada(InputAction.CallbackContext contexto)
    {
        if (contexto.started)
            Pular();
    }

    public void Pular()
    {
        if (pulos > 0)
        {
            pulos--;
            rb2D.AddForce(forcaDoPulo * rb2D.transform.up, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter(Collision outro)
    {
        if (outro.gameObject.CompareTag(tagResetaPulos))
            pulos = pulosValorInicial;

    }
}
