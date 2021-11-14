using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chao : MonoBehaviour
{
    Collider2D myCollider;
    Interagir jogador;
    Vector3 ponto;
    void Start()
    {
        myCollider = GetComponent<Collider2D>();
        jogador = FindObjectOfType<Interagir>();
    }

    
    void Update()
    {
        if (Input.touchCount > 0 )
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                
                ponto = Camera.main.ScreenToWorldPoint(touch.position);

                if (myCollider.bounds.Contains(ponto))
                {
                    Debug.Log(myCollider);
                    Debug.Log(ponto);
                    
                    jogador.Indicar();
                }
            }
            
        }
    }
}
