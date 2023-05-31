using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Puxar : MonoBehaviour
{
    public string tagObjetoSeraPuxado;
    public float distancia;
    public float velocidade;
    public bool sePuxa;
    private Rigidbody rb;
    private Transform pai;
    private FixedJoint fj;
    private bool jaColidiu;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pai = transform.parent;

        StartCoroutine(Vai());
    }

    IEnumerator Vai()
    {
        jaColidiu = false;
        float dist = distancia;

        while (dist > 0 && !jaColidiu)
        {
            rb.MovePosition(rb.position + velocidade
            * Time.deltaTime * rb.transform.forward);

            dist -= velocidade * Time.deltaTime;

            yield return new WaitForSeconds(Time.deltaTime);
        }

        if (!jaColidiu)
            StartCoroutine(Volta());
    }

    IEnumerator Volta()
    {
        while (Vector3.Distance(transform.position, pai.position) > 1.5f)
        {
            rb.MovePosition(rb.position + velocidade
            * Time.deltaTime * -rb.transform.forward);

            yield return new WaitForSeconds(Time.deltaTime);
        }

        if (fj)
            Destroy(fj);
    }
    
    IEnumerator SePuxa()
    {
        while (Vector3.Distance(transform.position, pai.position) > 1.5f)
        {
            pai.GetComponent<Rigidbody>().MovePosition(pai.position + velocidade
                * Time.deltaTime * rb.transform.forward);

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider outro)
    {
        if (!jaColidiu && outro.CompareTag(tagObjetoSeraPuxado))
        {
            jaColidiu = true;
            fj = outro.AddComponent<FixedJoint>();
            fj.connectedBody = rb;

            StopCoroutine(Vai());

            if (sePuxa)
                StartCoroutine(SePuxa());
            else
                StartCoroutine(Volta());
        }
    }
}
