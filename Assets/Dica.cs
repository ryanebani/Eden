using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dica : MonoBehaviour
{
    Animator anim;
    public float timer;
    bool check;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && check)
            {
                Interagir.podeAndar = true;
                check = false;
            }

            if (touch.phase == TouchPhase.Stationary)
            {
                timer += Time.deltaTime;
            }

            if (touch.phase == TouchPhase.Ended && timer >= 2)
            {
                check = true;
                Interagir.podeAndar = false;               
                timer = 0;
            }
        }

        if(timer >= 2f)
        {
            anim.SetBool("Indicar", true);
            Interagir.paraOndeVou = "";
        }   
    }

    public void False()
    {       
       anim.SetBool("Indicar", false);       
    }
}
