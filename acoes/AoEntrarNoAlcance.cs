using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AoEntrarNoAlcance : MonoBehaviour
{
    public string tagDoObjetoQueEntrarEmContato;
    public UnityEvent evento;

    /**Código feito para 2d*/
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(tagDoObjetoQueEntrarEmContato))
            evento.Invoke();
    }

    /**Código feito para 3d*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tagDoObjetoQueEntrarEmContato))
            evento.Invoke();
    }
}
