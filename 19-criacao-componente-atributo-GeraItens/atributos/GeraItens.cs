using System.Collections;
using UnityEngine;

public class GeraItens : MonoBehaviour
{
    public GameObject itemPrefab;
    public int quantidadeSerGerada;
    public float intervaloDeTempo;
    public bool seraDestruido;

    public void Start()
    {
        StartCoroutine(GerarObjetos());
    }

    public IEnumerator GerarObjetos()
    {
        while (quantidadeSerGerada == 0 || quantidadeSerGerada > 0)
        {
            Instantiate(itemPrefab, transform.position, transform.rotation);

            if (quantidade > 0)
                quantidade--;

            if (quantidade == 0 && seraDestruido)
            {
                Destroy(gameObject);
                yield break;
            }

            yield return new WaitForSeconds(intervaloDeTempo);
        }
    }
}
