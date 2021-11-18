using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjInt : MonoBehaviour
{
    [SerializeField] ObjIntOS objOS;
    Interagir jogador;

    string[] falasIdle;
    int indice;
    bool podeObservar;
    public string falaRandomizada;

    public void OnValidate()
    {
        if (objOS != null)
        {
            gameObject.name = objOS.nomeObj;
        }
       
    }

    private void Start()
    {
        if (objOS != null)
        {
            falasIdle = objOS.falasInspeção;
        }

        jogador = FindObjectOfType<Interagir>();
    }
    void Update() 
    {

    }

    public void RandomIdle()
    {
        indice = Random.Range(0, falasIdle.Length);
        for (int i = 0; i < falasIdle.Length; i++)
        {
            if (indice == i)
            {
                jogador.PodeIdle(falasIdle[i]);
                break;
            }
        }
        
    }
}
