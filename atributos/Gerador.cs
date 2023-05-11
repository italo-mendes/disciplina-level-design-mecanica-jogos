using UnityEngine;

public class Gerador : MonoBehaviour
{
    public GameObject prefab;
    public int qnt;
    public float espaco;
    public bool serDestruido;

    private void Start()
    {
        if (qnt > 0)
        {
            InvokeRepeating("GerarGameObject", 0f, espaco);
        }
        else
        {
            InvokeRepeating("GerarGameObject", 0f, espaco);
        }
    }

    private void GerarGameObject()
    {
        Instantiate(prefab, transform.position, transform.rotation);
        qnt--;

        if (quantidade == 0 && serDestruido)
        {
            Destroy(gameObject);
        }
    }
}
