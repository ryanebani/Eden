using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlvoMovendo : MonoBehaviour
{
    public bool chao;
    public Interagir jogador;
    public GameObject gizmo;
    public UnityEvent OnCheguei;
    

    private void Start()
    {
        //OnCheguei.AddListener();
    }

    private void OnMouseDown()
    {
        CaixaIdle.textoAbel = false;

        if (chao && DialogoController.podeClickar)
        {
            jogador.clickChao = true;
            jogador.paraOndeVou = gameObject.name;
        }

        if (!chao && DialogoController.podeClickar)
        {
            jogador.clickObj = true;
            jogador.alvoObj = gizmo.transform;
            jogador.paraOndeVou = gameObject.name;
        }
       
    }

    private void Update()
    {
        if (jogador.paraOndeVou == gameObject.name)
        {
            gizmo.SetActive(true);
            if (jogador.posJogador.position.x == gizmo.transform.position.x)
            {
                OnCheguei?.Invoke();
                jogador.paraOndeVou = "";
                gizmo.SetActive(false);
                if(GetComponent<ObjInt>() == null)
                    DialogoController.podeClickar = false;
            }
        }
        else
        {
            gizmo.SetActive(false);
        }
    }
}
