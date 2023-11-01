using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurarAoContato : MonoBehaviour
{
    [Header("Tag do gameObject que recebera a cura")]
    public string outroTag;
    public bool seDestroiNoContato;

    private Cura curaComponent;

    void Start()
    {
        if (!TryGetComponent<Cura>(out curaComponent))
            print("Adicione o componente <color=orange>Cura</color> ao GameObject.");
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
            go.GetComponent<Vida>().GetVida() + curaComponent.GetCura()
        );

        if (seDestroiNoContato)
            Destroy(gameObject);
    }
}
