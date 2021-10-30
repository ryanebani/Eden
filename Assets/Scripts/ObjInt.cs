using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjInt : MonoBehaviour
{
    public ObjIntOS ObjOS;
    public string falas;

    bool podeObservar;

    public TextMeshProUGUI falaObj;
   
    
    public void OnValidate()
    {
        gameObject.name = ObjOS.nomeObj;
        falas = ObjOS.falas;
    }
        
    void Update() 
    {

    }

    public void PodeIdle()
    {
        CaixaIdle.falaIdle = ObjOS.falas;
        CaixaIdle.idleDialogo = true;
    }
}
