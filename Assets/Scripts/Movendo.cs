using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movendo : MonoBehaviour
{
    Vector2 posAtu;
    Vector2 alvo;
    public GameObject circ;
    Vector3 ponto;
    bool mover;
    public Transform jogador;
    bool clickChao;
    


    void Start()
    {
        posAtu = new Vector3(jogador.position.x, jogador.position.y, jogador.position.z);
        alvo = posAtu;
    }

    private void OnMouseDown()
    {
        clickChao = true;
    }

    

    void Update()
    {
        if (clickChao)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

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

                if (touch.phase == TouchPhase.Ended)
                {
                    ponto = Camera.main.ScreenToWorldPoint(touch.position);
                    circ.SetActive(false);
                    if (mover)
                    {
                        alvo = new Vector2(ponto.x, jogador.position.y);
                        mover = false;
                        clickChao = false;
                    }

                }
            }
        }
        
        
        if(posAtu != alvo)
        {
            posAtu = Vector3.MoveTowards(posAtu, alvo, 5 * Time.deltaTime);
            jogador.position = posAtu;
        }

    }
}
