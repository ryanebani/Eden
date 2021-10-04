using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlvoMovendo : MonoBehaviour
{
    public bool chao;
    public Transform alvo;
    public Interagir jogador;
    
    private void OnMouseDown()
    {
        if (chao)
        {
            jogador.clickChao = true;
            jogador.paraOndeVou = gameObject.name;
        }
        if (chao == false)
        {
            jogador.clickObj = true;
            jogador.alvoObj = alvo;
            jogador.paraOndeVou = gameObject.name;
        }
       
    }

    private void Update()
    {
        if (jogador.paraOndeVou == gameObject.name)
        {
            alvo.gameObject.SetActive(true);
        }
        else
        {
            alvo.gameObject.SetActive(false);
        }
    }    
}
