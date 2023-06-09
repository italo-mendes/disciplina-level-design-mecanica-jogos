using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoAoContato : MonoBehaviour
{
    [Header("Tag do gameObject que recebera a cura")]
    public string outroTag;

    private Dano curaComponent;

    void Start()
    {
        if (!TryGetComponent<Dano>(out danoComponent))
        {
            print("Adicione o componente <color=orange>Dano</color> ao GameObject.");
        }
    }

    void OnCollisionEnter(Collision outro)
    {
        if (outro.gameObject.CompareTag(outroTag))
        {
            outro.gameObject.GetComponent<Vida>().SetVida(
                outro.gameObject.GetComponent<Vida>().GetVida()
                - danoComponent.GetDano()
            );

            if (seDestroiNoContato)
                Destroy(gameObject);
        }
    }
}
