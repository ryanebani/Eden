using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlvoChao : MonoBehaviour
{

    Interagir jogador;
    Vector3 ponto;
    void Start()
    {
        jogador = FindObjectOfType<Interagir>();   
    }

   
    void Update()
    {
        oi();
        //if (jogador.paraOndeVou == gameObject.name);
        //jogador.Andar(ponto);
        
    }

    void OnMouseDown()
    {
        Interagir.paraOndeVou = gameObject.name;
    }

    public void oi()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Ended)
            {
                ponto = Camera.main.ScreenToWorldPoint(touch.position);
            }
        }
    }
}
