using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegaObjeto : MonoBehaviour
{
    public string tagObjetoParaSelecionar;
    public float distanciaParaCarregamento;
    public string tagObjetoParaDeixar;
    private Collider coll;
    private bool colidiuEmAlgo;
    private RaycastHit hit;
    private GameObject objetoSelecionado;

    void Start()
    {
        coll = GetComponent<Collider>();
        objetoSelecionado = null;
    }

    public void BuscaObjeto()
    {
        if (objetoSelecionado == null)
        {
            colidiuEmAlgo = Physics.BoxCast(coll.bounds.center, transform.localScale,
            transform.forward, out hit, transform.rotation, 15.0f);

            if (colidiuEmAlgo && hit.collider.CompareTag(tagObjetoParaSelecionar))
            {
                hit.transform.position = transform.position;
                hit.transform.Translate(distanciaParaCarregamento * transform.forward);
                hit.transform.parent = transform;
                objetoSelecionado = hit.transform.gameObject;
            }
        }
        else
        {
            if (string.IsNullOrEmpty(tagObjetoParaDeixar))
            {
                objetoSelecionado.transform.parent = null;
            }
            else
            {
                colidiuEmAlgo = Physics.BoxCast(coll.bounds.center, transform.localScale,
                transform.forward, out hit, transform.rotation, 15.0f);

                if (colidiuEmAlgo && hit.collider.CompareTag(tagObjetoParaDeixar))
                {
                    objetoSelecionado.transform.parent = null;
                    objetoSelecionado.transform.position = hit.transform.position;
                    objetoSelecionado = null;
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if (colidiuEmAlgo)
        {
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
            Gizmos.DrawWireCube(transform.position + transform.forward * hit.distance, transform.localScale);
        }
        else
        {
            Gizmos.DrawRay(transform.position, transform.forward * 15.0f);
            Gizmos.DrawWireCube(transform.position + transform.forward * 15.0f, transform.localScale);
        }
    }
}
