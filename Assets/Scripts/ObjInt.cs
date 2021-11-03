using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjInt : MonoBehaviour
{
    [SerializeField] CaixaIdle inspecionar;

    public ObjIntOS objOS;
    public string[] falasIdle;

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
        
    void Update() 
    {

    }

    public void PodeIdle()
    {        
        CaixaIdle.textoAbel = true;
        RandomFala();
        for (int i = 0; i < falasIdle.Length; i++)
        {
            if (indice == i)
            {
                inspecionar.fala = falasIdle[i];
                break;
            }
        }
        inspecionar.caixaAnim.SetTrigger("TriggarFala");
    }

    public void RandomFala()
    {
        indice = Random.Range(0,falasIdle.Length);
    }
}
