using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class MovimentarParaFrenteRigidbody : MonoBehaviour
{
    public Velocidade velocidade;
    public MovimentarParaFrenteRigidbody movimentarParaFrenteRigidbody;

    public string tagPula;
    public float forcaPulo;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (!TryGetComponent<Velocidade>(out velocidade))
            print("Adicione o componente <color=orange>Velocidade</color> ao GameObject.");

        if(!TryGetComponent<MovimentarParaFrenteRigidbody>(out movimentarParaFrenteRigidbody))
            print("Adicione o componente <color=orange>MovimentarParaFrenteRigidbody</color> ao GameObject.");
    }

    private void FixedUpdate()
    {
        // Movimento horizontal
        float movimentoHorizontal = velocidade.GetVelocidade() * Time.fixedDeltaTime;
        Vector2 movimento = new Vector2(movimentoHorizontal, rb.velocity.y);
        rb.MovePosition(rb.position + movimento);

        // Verifica se está tocando em um objeto com a tag "JumpableObject"
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag(tagPula))
            {
                rb.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
                break;
            }
        }
    }
}
