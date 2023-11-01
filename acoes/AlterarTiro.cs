using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlterarTiro : MonoBehaviour
{
    [Header("Tag do gameObject que recebera o dano")]
    public string outroTag;
    public GameObject projetil;
    public int numeroDirecoes;
    public int variacaoNumeroDirecoes;
    public float anguloEntreDirecoes;
    public float variacaoAnguloEntreDirecoes;
    public bool seDestroi;

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

    public void Verificacoes(GameObject go)
    {
        if (projetil != null)
            go.BroadcastMessage("SetProjetil", projetil);

        if (numeroDirecoes > 0)
            go.BroadcastMessage("SetNumeroDirecoes", numeroDirecoes);

        if (variacaoNumeroDirecoes != 0)
            go.BroadcastMessage("VariacaoNumeroDirecoes", variacaoNumeroDirecoes);

        if (anguloEntreDirecoes > 0)
            go.BroadcastMessage("SetAnguloEntreDirecoes", anguloEntreDirecoes);

        if (variacaoAnguloEntreDirecoes != 0)
            go.BroadcastMessage("VariacaoAnguloEntreDirecoes", variacaoAnguloEntreDirecoes);

        if (seDestroi)
            Destroy(gameObject);
    }
}
