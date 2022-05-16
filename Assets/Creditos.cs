using System.Collections;
using UnityEngine;

public class Creditos : MonoBehaviour
{
    [SerializeField] float tempoDeTela;
    [SerializeField] float valorVel;
    float velocidade;

    Transform transformObjeto;

    Vector3 posInicial;

    void Start()
    {
        transformObjeto = GetComponent<Transform>();
        posInicial = GetComponent<Transform>().position;
    }

    void Update()
    {
        transformObjeto.Translate(Vector3.up * velocidade * Time.deltaTime);
    }

    public void SetCreditos()
    {
        velocidade = 0;
        transformObjeto.position = posInicial;
        StartCoroutine(ContagemAntes());
    }

    IEnumerator ContagemAntes()
    {
        yield return new WaitForSeconds(tempoDeTela);
        velocidade = valorVel;
    }

    public void Acelerar()
    {
        if (velocidade == valorVel)
        {
            velocidade *= 3;
        }
        else
            velocidade = valorVel;
    }
}
