using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class AlvoMovendo : MonoBehaviour
{
    [SerializeField] Transform destinoTransform;
    public bool chao;
    Interagir jogador;
    Vector3 destino;
    public UnityEvent OnCheguei;
    Collider2D col;

    private void Start()
    {
        destino = destinoTransform.position;
        jogador = FindObjectOfType<Interagir>();
        col = GetComponent<Collider2D>();
    }

    private void OnMouseDown()
    {
       jogador.paraOndeVou = gameObject.name;
       jogador.Indicar();
    }
    
    private void Update()
    {
        if (jogador.paraOndeVou == gameObject.name)
        {
            
            jogador.Andar(destino, chao);

            if (jogador.posJogador.position.x == destino.x && chao == false)
            { 
                OnCheguei?.Invoke();
                Debug.Log(jogador.paraOndeVou);
                jogador.paraOndeVou = "";
                jogador.OffSet();
                DialogoController.podeClickar = false;                       
            }
            
        }

    }

   
}
