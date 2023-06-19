using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoExplosao : MonoBehaviour
{

    /*
     * Quem vai receber o dano precisa ter os componentes:
     *  - Vida
     *  - Box Collider
     */

    public string tagDeQuemIraReceberDano;
    public int tempoDetonacao;
    public float raioDaExplosao;
    public Dano dano;

    // Start is called before the first frame update
    void Start()
    {
        if(!TryGetComponent<Dano>(out dano))
        {
            print("Adicione o component <color=orange>Dano</color> ap GameObject");
        }
        Destroy(gameObject, tempoDetonacao);
    }

    void OnDestroy()
    {
        Collider[] objetosNoRaio = Physics.OverlapSphere(transform.position, raioDaExplosao);

        foreach (Collider objeto in objetosNoRaio)
        {
            print("foreach");
            print(objeto.gameObject);
            if (objeto.gameObject.CompareTag(tagDeQuemIraReceberDano)){
                objeto.gameObject.GetComponent<Vida>().SetVida(
                    objeto.gameObject.GetComponent<Vida>().GetVida()
                    - dano.GetDano()
                );
               
            }
            print(objeto.gameObject.GetComponent<Vida>());
        }
    }

    /**Fun��o para mostrar a esfera de colis�o*/
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, raioDaExplosao);
    }
}
