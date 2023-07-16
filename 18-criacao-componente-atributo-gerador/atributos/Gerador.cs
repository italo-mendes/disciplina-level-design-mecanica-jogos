using System.Collections;
using UnityEngine;

public class Gerador : MonoBehaviour
{
    public GameObject prefab; 
    public int quantidade; 
    public float intervaloDeTempo; 
    public bool seraDestruido; 

    private void Start()
    {
        StartCoroutine(GerarObjetos());
    }

    private IEnumerator GerarObjetos()
    {
        while (quantidade > 0)
        {
            Instantiate(prefab, transform.position, transform.rotation);

            quantidade--;

            yield return new WaitForSeconds(intervaloDeTempo);
        }

        if (seraDestruido)
            Destroy(gameObject);
    }
}
