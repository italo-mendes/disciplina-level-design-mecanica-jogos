using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestruir : MonoBehaviour
{
    [Header("Tag do gameObject que destuirá esse gameObject")]
    public string outroTag;
    public float tempoAntesDeSeDestruir;

    void OnCollisionEnter(Collision outro)
    {
        if (outro.gameObject.CompareTag(outroTag))
            Destroy(gameObject, tempoAntesDeSeDestruir);
    }

    void OnTriggerEnter(Collider outro)
    {
        if (outro.gameObject.CompareTag(outroTag))
            Destroy(gameObject, tempoAntesDeSeDestruir);
    }

    void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag(outroTag))
            Destroy(gameObject, tempoAntesDeSeDestruir);
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag(outroTag))
            Destroy(gameObject, tempoAntesDeSeDestruir);
    }
}
