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
    Collider2D col;

    private void Start()
    {
        gizmoPos = gizmoTransform.position;
        jogador = FindObjectOfType<Interagir>();
        col = GetComponent<Collider2D>();
    }

    private void OnMouseDown()
    {        
        jogador.paraOndeVou = gameObject.name;
    }
    
    private void Update()
    {
        /*if (Input.touchCount > 0)
        {
            Touch toque = Input.GetTouch(0);
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            if (toque.phase == TouchPhase.Ended && col.OverlapPoint(wp))
            {
                jogador.paraOndeVou = gameObject.name;                
            }
        }*/

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
