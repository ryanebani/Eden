using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transicao : MonoBehaviour
{
    public  bool podeAction;
    public  bool transicao;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {       
        if (transicao == true)
        {
            GetComponent<Animator>().SetTrigger("FadeOut");
            transicao = false;
        }
    }

    public void CanAction()
    {
        podeAction = true;       
    }
        
}
