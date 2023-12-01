using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlterarTipoTiro : MonoBehaviour
{
    [Header("Tag do gameObject que terá o tipo do tiro alterado")]
    public string outroTag;
    public enum TiposTiros { 
        AtirarEmArco, 
        AtirarEmArcoConcentrado, 
        AtirarEmCirculo, 
        AtirarEmConeAleatorio, 
        AtirarEmRetangulo 
    };
    public TiposTiros tipoTiroParaAplicar;
    public bool seDestroi;
    private Component[] componentes;

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
        componentes = go.transform.GetComponentsInChildren<AtirarEmArco>();

        if (tipoTiroParaAplicar == TiposTiros.AtirarEmArco)
            foreach (AtirarEmArco c in componentes)
                c.enabled = true;
        else
            foreach (AtirarEmArco c in componentes)
                c.enabled = false;


        componentes = go.transform.GetComponentsInChildren<AtirarEmArcoConcentrado>();

        if (tipoTiroParaAplicar == TiposTiros.AtirarEmArcoConcentrado)
            foreach (AtirarEmArcoConcentrado c in componentes)
                c.enabled = true;
        else
            foreach (AtirarEmArcoConcentrado c in componentes)
                c.enabled = false;


        componentes = go.transform.GetComponentsInChildren<AtirarEmCirculo>();

        if (tipoTiroParaAplicar == TiposTiros.AtirarEmCirculo)
            foreach (AtirarEmCirculo c in componentes)
                c.enabled = true;
        else
            foreach (AtirarEmCirculo c in componentes)
                c.enabled = false;


        componentes = go.transform.GetComponentsInChildren<AtirarEmConeAleatorio>();

        if (tipoTiroParaAplicar == TiposTiros.AtirarEmConeAleatorio)
            foreach (AtirarEmConeAleatorio c in componentes)
                c.enabled = true;
        else
            foreach (AtirarEmConeAleatorio c in componentes)
                c.enabled = false;


        componentes = go.transform.GetComponentsInChildren<AtirarEmRetangulo>();

        if (tipoTiroParaAplicar == TiposTiros.AtirarEmRetangulo)
            foreach (AtirarEmRetangulo c in componentes)
                c.enabled = true;
        else
            foreach (AtirarEmRetangulo c in componentes)
                c.enabled = false;


        if (seDestroi)
            Destroy(gameObject);
    }
}
