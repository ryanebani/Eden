using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassaroAmb : MonoBehaviour
{
    [SerializeField]
    protected AudioClip[] clipes;

    private AudioSource origem;

    [SerializeField] private float min;
    [SerializeField] private float max;

    private Transform objeto;
    private Vector3 coordenada;

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
        PassaroSom();
        EscolherSom();
        StartCoroutine(EsperarSom());
    }

    void Update()
    {
   
    }

    private IEnumerator EsperarSom()
    {
        yield return new WaitForSeconds(Random.Range(min, max));
        ChamarSom();
    }

    private void PassaroSom()
    {
        SetCord();

        objeto.position = new Vector3 (coordenada.x, objeto.position.y, objeto.position.z);
    }

    private void SetCord()
    {
        float sorteador = (Random.Range(-25, 25));
        coordenada.x = sorteador;
    }

}
