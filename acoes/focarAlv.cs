using UnityEngine;

public class FocarEmAlvo : MonoBehaviour
{
    public Transform alvo;

    private void Update()
    {
        if (alvo != null)
        {
            
            Vector3 direcao = alvo.position - transform.position;
            
              transform.rotation = Quaternion.LookRotation(direcao, Vector3.up);
        }
    }
}