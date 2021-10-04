using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interagir : MonoBehaviour
{
    
    Transform posJogador;

    Vector2 alvo;    
    Vector2 posAtu;
    Vector3 ponto;   
    
    public GameObject circ;
    public Transform alvoObj;
    public bool clickObj;
    public bool clickChao;

    bool mover;

    void Start()
    {
        posJogador = GetComponent<Transform>();
        posAtu = new Vector3(posJogador.position.x, posJogador.position.y, posJogador.position.z);
        alvo = posAtu;
        
    }

    void Update()
    {  

        if (clickObj)
        {
            AndarObj();
        }
        
        if (clickChao)
        {
            AndarChao();
        }

        if (posAtu != alvo)
        {
            if (posAtu.x > alvo.x)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            posAtu = Vector3.MoveTowards(posAtu, alvo, 5 * Time.deltaTime);
            posJogador.position = posAtu;
        }
        
    }

    public void AndarObj()
    {
        ponto = new Vector3(alvoObj.position.x, alvoObj.position.y, alvoObj.position.z);
        mover = true;
        //circ.SetActive(false);
        if (mover)
        {
            alvo = new Vector2(ponto.x, posJogador.position.y);
            mover = false;
            clickObj = false;
        }        
        
    }

    public void AndarChao()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            //Bolinha do toque
            if (touch.phase == TouchPhase.Began)
            {
                circ.SetActive(true);
                ponto = Camera.main.ScreenToWorldPoint(touch.position);
                circ.transform.position = new Vector2(ponto.x, ponto.y);
                mover = true;
            }
            //Cancelar Movimento
            if (touch.phase == TouchPhase.Moved)
            {
                ponto = Camera.main.ScreenToWorldPoint(touch.position);
                circ.transform.position = new Vector2(ponto.x, ponto.y);
                mover = false;
            }

            //Movimento
            if (touch.phase == TouchPhase.Ended)
            {
                ponto = Camera.main.ScreenToWorldPoint(touch.position);
                circ.SetActive(false);
                if (mover)
                {
                    alvo = new Vector2(ponto.x, posJogador.position.y);
                    mover = false;
                    clickChao = false;
                }

            }
        }
    }
}