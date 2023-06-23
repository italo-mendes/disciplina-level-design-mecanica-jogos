using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtirarEmCirculo : MonoBehaviour
{
    public GameObject projetil;
    public int numeroDirecoes;
    public float tempoEntreDisparos;
    public float raioDosDisparos;
    public bool x;
    public bool y;
    public bool z;
    private float angulo;
    private Quaternion rotacaoInicial;

    void Start()
    {
        angulo =  360/numeroDirecoes;
        rotacaoInicial = transform.localRotation;

        StartCoroutine(Atira());
    }

    IEnumerator Atira()
    {
        while (true)
        {
            if(numeroDirecoes % 2 == 0){
                if (x && y  && z )
                {
                    Instantiate(projetil, transform.position, transform.rotation);
                    for (int i = 1; i <= numeroDirecoes - 1; i++)
                    {
                        transform.Rotate(angulo * i, 0.0f, 0.0f, Space.Self);
                        Instantiate(projetil, transform.position, transform.rotation);
                    }
                    transform.localRotation = rotacaoInicial;
                    Instantiate(projetil, transform.position, transform.rotation);
                    for (int i = 1; i <= numeroDirecoes - 1; i++)
                    {
                        if( i != 1)
                        {
                            transform.Rotate(0.0f, angulo * i, 0.0f, Space.Self);
                            Instantiate(projetil, transform.position, transform.rotation);
                        }
                        else if(i != numeroDirecoes-1){
                            transform.Rotate(0.0f, angulo * i, 0.0f, Space.Self);
                            Instantiate(projetil, transform.position, transform.rotation);
                        }
                    }
                    transform.localRotation = rotacaoInicial;
                }
                else if (x && y )
                {
                    Instantiate(projetil, transform.position, transform.rotation);
                    for (int i = 1; i <= numeroDirecoes - 1; i++)
                    {
                        transform.Rotate(angulo * i, 0.0f, 0.0f, Space.Self);
                        Instantiate(projetil, transform.position, transform.rotation);
                    }
                    transform.localRotation = rotacaoInicial;
                    Instantiate(projetil, transform.position, transform.rotation);
                    for (int i = 1; i <= numeroDirecoes - 1; i++)
                    {
                        if (i != 1)
                        {
                            transform.Rotate(0.0f, angulo * i, 0.0f, Space.Self);
                            Instantiate(projetil, transform.position, transform.rotation);
                        }
                        else if (i != numeroDirecoes - 1)
                        {
                            transform.Rotate(0.0f, angulo * i, 0.0f, Space.Self);
                            Instantiate(projetil, transform.position, transform.rotation);
                        }
                    }
                    transform.localRotation = rotacaoInicial;
                }
                else if (x && z)
                {
                    Instantiate(projetil, transform.position, transform.rotation);
                    for (int i = 1; i <= numeroDirecoes - 1; i++)
                    {
                        transform.Rotate(angulo * i, 0.0f, 0.0f, Space.Self);
                        Instantiate(projetil, transform.position, transform.rotation);
                    }
                    transform.localRotation = rotacaoInicial;
                    Instantiate(projetil, transform.position, transform.rotation);
                    for (int i = 1; i <= numeroDirecoes - 1; i++)
                    {
                        if (i != 1)
                        {
                            transform.Rotate(0.0f, angulo * i, 0.0f, Space.Self);
                            Instantiate(projetil, transform.position, transform.rotation);
                        }
                        else if (i != numeroDirecoes - 1)
                        {
                            transform.Rotate(0.0f, angulo * i, 0.0f, Space.Self);
                            Instantiate(projetil, transform.position, transform.rotation);
                        }
                    }
                    transform.localRotation = rotacaoInicial;
                }
                else if (x)
                {
                    for (int i = 0; i < numeroDirecoes; i++)
                    {
                        transform.Rotate(angulo * i, 0.0f, 0.0f, Space.Self);
                        Instantiate(projetil, transform.position, transform.rotation);
                        transform.localRotation = rotacaoInicial;
                    }
                }
                else if (y)
                {
                    for (int i = 0; i < numeroDirecoes; i++)
                    {
                        transform.Rotate(0.0f, angulo * i, 0.0f, Space.Self);
                        Instantiate(projetil, transform.position, transform.rotation);
                        transform.localRotation = rotacaoInicial;
                    }
                }
                else if (z)
                {
                    for (int i = 0; i < numeroDirecoes; i++)
                    {
                        transform.Rotate(0.0f, 0.0f, angulo * i, Space.Self);
                        Instantiate(projetil, transform.position, transform.rotation);
                        transform.localRotation = rotacaoInicial;
                    }
                }
            }
            else
            {
                if(x && y && z)
                {
                    for (int i = 0; i < numeroDirecoes; i++)
                    {
                        transform.Rotate(angulo * i, 0.0f, 0.0f, Space.Self);
                        Instantiate(projetil, transform.position, transform.rotation);
                        transform.localRotation = rotacaoInicial;
                    }
                    for (int i = 0; i < numeroDirecoes; i++)
                    {
                        if(i != 0 || i != numeroDirecoes )
                        {
                        transform.Rotate(0.0f, angulo * i, 0.0f, Space.Self);
                        Instantiate(projetil, transform.position, transform.rotation);
                        transform.localRotation = rotacaoInicial;
                        }
                    }
                }
                if(x && y)
                {
                    for (int i = 0; i < numeroDirecoes; i++)
                    {
                        transform.Rotate(angulo * i, 0.0f, 0.0f, Space.Self);
                        Instantiate(projetil, transform.position, transform.rotation);
                        transform.localRotation = rotacaoInicial;
                    }
                    for (int i = 0; i < numeroDirecoes; i++)
                    {
                        if(i != 0 || i != numeroDirecoes )
                        {
                        transform.Rotate(0.0f, angulo * i, 0.0f, Space.Self);
                        Instantiate(projetil, transform.position, transform.rotation);
                        transform.localRotation = rotacaoInicial;
                        }
                    }
                }
                if(x && z)
                {
                    for (int i = 0; i < numeroDirecoes; i++)
                    {
                        transform.Rotate(angulo * i, 0.0f, 0.0f, Space.Self);
                        Instantiate(projetil, transform.position, transform.rotation);
                        transform.localRotation = rotacaoInicial;
                    }
                    for (int i = 0; i < numeroDirecoes; i++)
                    {
                        if(i != 0 || i != numeroDirecoes )
                        {
                        transform.Rotate(0.0f, angulo * i, 0.0f, Space.Self);
                        Instantiate(projetil, transform.position, transform.rotation);
                        transform.localRotation = rotacaoInicial;
                        }
                    }
                }
                else if(x)
                {
                    for (int i = 0; i < numeroDirecoes ; i++)
                    {
                        transform.Rotate(angulo * i, 0.0f, 0.0f, Space.Self);
                        Instantiate(projetil, transform.position, transform.rotation);
                        transform.localRotation = rotacaoInicial;
                    }
                    
                }
                else if(y)
                {
                    for (int i = 0; i < numeroDirecoes ; i++)
                    {
                        transform.Rotate(0.0f, angulo * i, 0.0f, Space.Self);
                        Instantiate(projetil, transform.position, transform.rotation);
                        transform.localRotation = rotacaoInicial;
                    }
                    
                }
                else if(z)
                {
                    for (int i = 0; i < numeroDirecoes ; i++)
                    {
                        transform.Rotate(0.0f, 0.0f, angulo * i, Space.Self);
                        Instantiate(projetil, transform.position, transform.rotation);
                        transform.localRotation = rotacaoInicial;
                    }
                    
                }
            }

            yield return new WaitForSeconds(tempoEntreDisparos);
        }
    }
}
