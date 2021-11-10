using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class AlvoMovendo : MonoBehaviour
{
    [SerializeField] Transform gizmoTransform;
    public bool chao;
    Interagir jogador;    
    Vector3 gizmoPos;
    public UnityEvent OnCheguei;


    private void Start()
    {
        gizmoPos = gizmoTransform.position;
        jogador = FindObjectOfType<Interagir>();
    }


    private void OnMouseDown()
    {        
        jogador.paraOndeVou = gameObject.name;
    }

    private void Update()
    {      


        if (jogador.paraOndeVou == gameObject.name)
        {
            jogador.Andar(gizmoPos, chao);        

            if (jogador.posJogador.position.x == gizmoPos.x)
            {  
                OnCheguei?.Invoke();
                jogador.paraOndeVou = "";
                DialogoController.podeClickar = false;                       
            }
        }

    }
}
