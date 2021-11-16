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

    Interagir jogador;
    Vector3 destino;
    Collider2D coll;
       
    private void Start()
    {
        destino = destinoTransform.position;
        jogador = FindObjectOfType<Interagir>();
        coll = GetComponent<Collider2D>();
    }

    private void OnMouseUp()
    {
       if(Interagir.podeAndar)
       Interagir.paraOndeVou = gameObject.name;
       
         
    }
    
    private void Update()
    {
        if (Interagir.paraOndeVou == gameObject.name)
        {
            jogador.Andar(destino, chao);            
            if (jogador.posJogador.position.x == destino.x && chao == false)
            {                
                if (direita)
                {
                    Interagir.olharDireita = true;
                }
                OnCheguei?.Invoke();
                if (NPC)
                {
                    jogador.OffSet();
                }
                Interagir.paraOndeVou = "";
                DialogoController.podeClickar = false;                       
            }
        }

    }

   
}
