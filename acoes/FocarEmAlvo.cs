using UnityEngine;

public class FocarEmAlvo : MonoBehaviour
{
    public Transform alvo;

    private void Update()
    {
        if (alvo)
            transform.LookAt(alvo, Vector3.up);
    }
}
