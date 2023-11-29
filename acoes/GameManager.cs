using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager gm = null;

    public int pontuacao;
    public float contadorTempo;
    public TMP_Text tempoText;
    public TMP_Text pontuacaoText;
    public UnityEvent quandoAcabarOTempo;

    private void Awake()
    {
        if (gm == null)
            gm = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        pontuacao = 0;

        if (contadorTempo > 0)
            StartCoroutine(ContaTempoJogo());
    }

    public void SetPontuacao(int pont)
    {
        pontuacao = pont;
        pontuacaoText.text = pontuacao.ToString();
    }

    public void VariacaoPontuacao(int pont)
    {
        pontuacao += pont;
        pontuacaoText.text = pontuacao.ToString();
    }

    public IEnumerator ContaTempoJogo()
    {
        while (contadorTempo > 0)
        {
            contadorTempo--;

            tempoText.text =
                Mathf.FloorToInt(contadorTempo / 60).ToString() + ":" +
                Mathf.FloorToInt(contadorTempo % 60).ToString("00");

            yield return new WaitForSeconds(1.0f);
        }

        quandoAcabarOTempo.Invoke();
    }
}
