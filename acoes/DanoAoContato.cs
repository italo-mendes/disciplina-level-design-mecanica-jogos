using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoAoContato : MonoBehaviour
{
    [Header("Tag do gameObject que recebera o dano")]
    public string outroTag;
    public bool seDestroiNoContato;

    private Dano danoComponent;

    void Start()
    {
        if (!TryGetComponent<Dano>(out danoComponent))
            print("Adicione o componente <color=orange>Dano</color> ao GameObject.");
    }

    void OnCollisionEnter(Collision outro)
    {
        if (outro.gameObject.CompareTag(outroTag))
            Verificacoes(outro.gameObject);
    }

    void OnTriggerEnter(Collider outro)
    {
        if (outro.gameObject.CompareTag(outroTag))
            Verificacoes(outro.gameObject);
    }

    void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag(outroTag))
            Verificacoes(outro.gameObject);
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag(outroTag))
            Verificacoes(outro.gameObject);
    }

    void Verificacoes(GameObject go)
    {
        go.GetComponent<Vida>().SetVida(
            go.GetComponent<Vida>().GetVida() - danoComponent.GetDano()
        );

        if (seDestroiNoContato)
            Destroy(gameObject);
    }
}
