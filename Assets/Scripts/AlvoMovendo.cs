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
        }
        else
        {
            jogador.clickObj = true;
            jogador.alvoObj = alvo;                       
        }
       
    }
}
