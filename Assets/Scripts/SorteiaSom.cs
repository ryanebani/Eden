using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorteiaSom : MonoBehaviour
{

    private AudioSource origem;

    void Start()
    {
        origem = GetComponent<AudioSource>();
    }

    public void EscolherSom(AudioClip[] clipes)
    {
        origem.clip = null;
        origem.clip = clipes[Random.Range(0, clipes.Length)];
        origem.Play();
    }
}
