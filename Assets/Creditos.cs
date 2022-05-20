using System.Collections;
using UnityEngine;

public class Creditos : MonoBehaviour
{

    [SerializeField] float tempoDeTela;
    [SerializeField] float valorVel;
    float velocidade;

    Transform transformObjeto;
   [SerializeField] Transform transformAlheio;

    Vector3 posInicial;

    bool creditosRolando;

    void Start()
    {
        transformObjeto = GetComponent<Transform>();
        posInicial = GetComponent<Transform>().position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Acelerar();
        }

        if (Input.GetMouseButtonUp(0))
        {
            Mover();
        }

        if(creditosRolando)
        transformObjeto.Translate(Vector3.up * velocidade * Time.deltaTime);

        if (transformObjeto.position.y >= transformAlheio.position.y)
        {
            Parar();
            DesligarCreditos();
        }
    }

    public void SetCreditos()
    {
        velocidade = 0;
        transformObjeto.position = posInicial;
        StartCoroutine(ContagemAntes());
    }

    public void DesligarCreditos()
    {
        creditosRolando = false;
    }

    IEnumerator ContagemAntes()
    {
        yield return new WaitForSeconds(tempoDeTela);
        creditosRolando = true;
    }

    private void Mover()
    {
        velocidade = valorVel;
    }

    private void Acelerar()
    {
        velocidade *= 4;
    }

    private void Parar()
    {
        velocidade = 0;
    }

}
