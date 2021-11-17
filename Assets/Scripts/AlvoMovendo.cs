using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class AlvoMovendo : MonoBehaviour
{
    [SerializeField] Transform destinoTransform;
    public bool chao;
    public bool NPC;
    public bool direita;
    public UnityEvent OnCheguei;
    Vector2 ponto;

    Interagir jogador;
    Vector3 destino;
    Collider2D coll;
       
    private void Start()
    {
        destino = destinoTransform.position;
        jogador = FindObjectOfType<Interagir>();
        coll = GetComponent<Collider2D>();        
    }

    public void MouseUp()
    {
        if (Interagir.podeAndar)
        {
            Interagir.paraOndeVou = gameObject.name;
        }
       
       Inventario.fecharIventario = true;
         
    }
    
    private void Update()
    {
       /* if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                ponto = Camera.main.ScreenToWorldPoint(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(ponto, -Vector2.up, 0.05f);

                if (hit.collider. name == gameObject.name)
                {
                    Interagir.paraOndeVou = gameObject.name;
                }
            }
        }*/



        if (Interagir.paraOndeVou == gameObject.name)
        {
            jogador.Andar(destino, chao);            
            if (jogador.posJogador.position.x == destino.x && chao == false)
            {                
                if (destino.x < transform.position.x)
                {
                    Interagir.olharDireita = true;
                }
                else
                {
                    Interagir.olharDireita = false;
                }
                OnCheguei?.Invoke();

                if (NPC)
                {
                    jogador.OffSet();
                }
                Interagir.paraOndeVou = "";
                //DialogoController.podeClickar = false;                       
            }
        }

    }

   
}
