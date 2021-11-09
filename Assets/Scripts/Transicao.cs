using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transicao : MonoBehaviour
{
    public bool podeAction;
    public bool transicao;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {       
        if (transicao == true)
        {
           animator.SetTrigger("FadeOut");
           transicao = false;
        }
    }

    public void CanAction()
    {
        podeAction = true;       
    }
        
}
