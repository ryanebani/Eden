using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inicio : MonoBehaviour
{
    public Animator logo;

    public Animator clicke;

    public Animator jogar;
    public Animator creditos;



    void Start()
    {
        
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            logo.SetTrigger("Mover");
            clicke.SetTrigger("Mover");
        }
    }

    public void Desaparecer()
    {
        clicke.gameObject.SetActive(false);
    }

    public void Aparecer()
    {
        jogar.gameObject.SetActive(true);
        creditos.gameObject.SetActive(true);
        //jogar.SetTrigger("Mover");
        //creditos.SetTrigger("Mover");
    }
}
