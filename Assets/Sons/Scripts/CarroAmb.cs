using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroAmb : MonoBehaviour
{
    [SerializeField]
    protected AudioClip[] clipes;

    private AudioSource origem;

    [SerializeField] private float min;
    [SerializeField] private float max;

    [SerializeField] private float velocidade;

    private Transform objeto;
    private Vector3 coordenada;

    private bool mover = false;

    void Start()
    {
        origem = GetComponent<AudioSource>();
        objeto = GetComponent<Transform>();
        StartCoroutine(EsperarSom());
    }

    private void EscolherSom()
    {
        origem.clip = clipes[Random.Range(0, clipes.Length)];
        origem.Play();
    }

    private void ChamarSom()
    {
        CarroSom();
        EscolherSom();
        //VelocEspecífica();
        StartCoroutine(EsperarSom());
    }

    void Update()
    {
        if (mover)
        {
            objeto.position = new Vector3(objeto.position.x + velocidade, objeto.position.y, objeto.position.z * Time.deltaTime);
        }

        if (!origem.isPlaying)
        {
            mover = false;
        }
    }

    private IEnumerator EsperarSom()
    {
        yield return new WaitForSeconds(Random.Range(min, max));
        ChamarSom();
    }

    private void CarroSom()
    {
        SetCord();
        SetVel();

        objeto.position = coordenada;

        mover = true;
    }

    private void SetCord()
    {
        int sorteador = (Random.Range(0, 2));
        if (sorteador == 0)
        {
            coordenada.x = -35;
        }
        else
        {
            coordenada.x = 35;
        }
    }

    private void SetVel()
    {
        if (coordenada.x <= 0)
        {
            if (velocidade >= 0)
                velocidade *= 1;
            else
                velocidade *= -1;
        }
        else
        {
            if (velocidade >= 0)
                velocidade *= -1;
            else
                velocidade *= 1;
        }
    }
}
