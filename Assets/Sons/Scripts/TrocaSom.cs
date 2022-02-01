using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocaSom : MonoBehaviour
{
    private AudioSource origem;
    [SerializeField]
    private AudioClip[] clipes;

    private int contagem = 0;

    void Start()
    {
        origem = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!origem.isPlaying)
        {
           TrocarSom();
        }
    }
    public void TrocarSom()
    {
        if (contagem == clipes.Length)
        {
            contagem = 0;
        }

        origem.clip = null;
        origem.clip = clipes[contagem];
        origem.Play();
        contagem++;
    }
}

