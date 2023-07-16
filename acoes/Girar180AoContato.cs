using UnityEngine;

public class Girar180AoContato : MonoBehaviour
{
    public string tagDoAcionador;
    public bool girarNoEixoX;
    public bool girarNoEixoY;
    public bool girarNoEixoZ;
    public float velocidadeDeRotacao;
    public float tempoParaVoltar;

    public bool rotacaoAtivada;
    private Quaternion rotacaoInicial;
    private float tempoPassado = 0f;

    private void Start()
    {
        rotacaoInicial = transform.rotation;
        rotacaoAtivada = false
        girarNoEixoX = true;
        girarNoEixoY = true;
        girarNoEixoZ = true;
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

    IEnumerator Girar(){
        if (girarNoEixoX || girarNoEixoY || girarNoEixoZ)
        {
            rotacaoAtivada = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == tagDoAcionador)
        {
            StartCoroutine(Girar());
        }
    }
}