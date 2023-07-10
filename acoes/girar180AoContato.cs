using UnityEngine;

public class Girar180AoContato : MonoBehaviour
{
    public string tagDoAcionador;
    public bool girarNoEixoX = true;
    public bool girarNoEixoY = true;
    public bool girarNoEixoZ = true;
    public float velocidadeDeRotacao = 1f;
    public float tempoParaVoltar = 1f;

    private bool rotacaoAtivada = false;
    private Quaternion rotacaoInicial;
    private float tempoPassado = 0f;

    private void Start()
    {
        rotacaoInicial = transform.rotation;
    }

    private void Update()
    {
        if (rotacaoAtivada)
        {
           Quaternion novaRotacao = rotacaoInicial * Quaternion.Euler(
                girarNoEixoX ? 180f : 0f,
                girarNoEixoY ? 180f : 0f,
                girarNoEixoZ ? 180f : 0f
            );
             transform.rotation = Quaternion.Slerp(transform.rotation, novaRotacao, velocidadeDeRotacao * Time.deltaTime);

            if (tempoPassado >= tempoParaVoltar && tempoParaVoltar > 0f)
            {
                rotacaoAtivada = false;
                tempoPassado = 0f;
            }
            else
            {
                tempoPassado += Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tagDoAcionador))
        {
             if (girarNoEixoX || girarNoEixoY || girarNoEixoZ)
            {
                rotacaoAtivada = true;
            }
        }
    }
}