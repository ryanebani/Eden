using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movendo : MonoBehaviour
{
    Vector2 atu;
    Vector2 alvo;
    public GameObject circ;
    Vector3 ponto;
    bool mover;


    void Start()
    {
        
        atu = new Vector3(transform.position.x, transform.position.y, transform.position.z);
     
    }

    
    void FixedUpdate()
    {
        /*
        if(Input.GetMouseButtonDown(0))
        {
            ponto = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            alvo = new Vector2(ponto.x, ponto.y);
            Debug.Log(Input.mousePosition);
        }
        */

        

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                circ.SetActive(true);
                ponto = Camera.main.ScreenToWorldPoint(touch.position);
                circ.transform.position = new Vector2(ponto.x, ponto.y);
                mover = true;
            }
            
            if(touch.phase == TouchPhase.Moved)
            {
                ponto = Camera.main.ScreenToWorldPoint(touch.position);
                circ.transform.position = new Vector2(ponto.x, ponto.y);
                mover = false;
            }

            if(touch.phase == TouchPhase.Ended)
            {
                ponto = Camera.main.ScreenToWorldPoint(touch.position);
                circ.SetActive(false);
                if(mover)
                {
                    alvo = new Vector2(ponto.x, ponto.y);
                    mover = false;
                }
                
            }
        }

        


        if(atu != alvo)
        {
            atu = Vector3.MoveTowards(atu, alvo, 5 * Time.deltaTime);
            transform.position = atu;
        }
        

    }
}
