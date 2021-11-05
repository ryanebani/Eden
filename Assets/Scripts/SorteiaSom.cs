using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorteiaSom : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] clipes;

    private AudioSource origem;

    void Start()
    {
        origem = GetComponent<AudioSource>();
    }

    protected void EscolherSom()
    {
        origem.clip = clipes[Random.Range(0, clipes.Length)];
        origem.Play();
    }
}
