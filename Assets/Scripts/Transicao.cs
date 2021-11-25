using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transicao : MonoBehaviour
{
    public bool podeAction;
    public bool transicao;
    AudioSource audioSource;
    private Animator animator;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {       
        if (transicao == true)
        {
           animator.SetBool("Ligar", true);
           transicao = false;
        }
    }

    public void CanAction()
    {
        podeAction = true;       
    }

    public void CantAction()
    {
        podeAction = false;
        animator.SetBool("Ligar", false);

    }
    public void Som(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
