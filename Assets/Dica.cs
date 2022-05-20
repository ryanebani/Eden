using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dica : MonoBehaviour
{
    Animator anim;
    float timer;
    bool check;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            timer += Time.deltaTime;

            if (timer >= 1.5f)
            {
                timer = 0;
                anim.SetBool("Indicar", true);
                check = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (timer < 1.5f) timer = 0;
            if (check)
            {
                Interagir.paraOndeVou = "";
                check = false;
            }
   
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            bool tocou = false;

            if (touch.phase == TouchPhase.Began)
            {
                timer = 0;
                tocou = true;
            }

            if(tocou)
            {
                timer += Time.deltaTime;
            }
            

            if (touch.phase == TouchPhase.Ended)
            {
                tocou = false;
                timer = 0;
                if (check)
                {
                    Interagir.paraOndeVou = "";
                    check = false;
                }
            }

            if (timer >= 1.5f)
            {                
                timer = 0;
                anim.SetBool("Indicar", true);
                check = true;
            }
        }  
    }

    public void False()
    {       
       anim.SetBool("Indicar", false);       
    }
}
