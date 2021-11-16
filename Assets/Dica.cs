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
            
            if (touch.phase == TouchPhase.Stationary)
            {
                timer += Time.deltaTime;
            }
            

            if (touch.phase == TouchPhase.Ended)
            {
                timer = 0;
                if (check)
                {
                    Interagir.paraOndeVou = "";
                    check = false;
                }
            }

            if (timer >= 2)
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
