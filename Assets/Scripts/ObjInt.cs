using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjInt : MonoBehaviour
{
    [SerializeField] CaixaIdle inspecionar;
    [SerializeField] ObjIntOS objOS;

    string[] falasIdle;
    int indice;
    bool podeObservar;

    public void OnValidate()
    {
        if (objOS != null)
        {
            gameObject.name = objOS.nomeObj;
            falasIdle = objOS.falasInspeção;
        }
       
    }

    private void Start()
    {
       // GameObject.FindGameObjectsWithTag("NPC");
    }
    void Update() 
    {

    }

    public void PodeIdle()
    {
        inspecionar.LigarTexto();
        indice = Random.Range(0, falasIdle.Length);
        for (int i = 0; i < falasIdle.Length; i++)
        {
            if (indice == i)
            {
                inspecionar.SetFala(falasIdle[i]);
                break;
            }
        }
        
    }
}
