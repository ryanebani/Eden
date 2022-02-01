using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorteadorSFX : MonoBehaviour
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

    private void ChamarSom()
    {
        if (gameObject.activeInHierarchy)
        {
            origem.clip = clipes[Random.Range(0, clipes.Length)];
            origem.Play();
            StartCoroutine(EsperarSom());
        }
        else
        {
            StartCoroutine(EsperarSom());
        }
    }

    private IEnumerator EsperarSom()
    {
        yield return new WaitForSeconds(Random.Range(min, max));
        ChamarSom();
    }

}
