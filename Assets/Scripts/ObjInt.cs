using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjInt : MonoBehaviour
{
    public ObjIntOS ObjOS;
    public string falaIdle;
    [SerializeField] CaixaIdle caixaIdle;

    bool podeObservar;

    public void OnValidate()
    {
        gameObject.name = ObjOS.nomeObj;
        falaIdle = ObjOS.falas;
    }
        
    void Update() 
    {

    }

    public void PodeIdle()
    {
        CaixaIdle.textoAbel = true;
        caixaIdle.fala = falaIdle;
        caixaIdle.caixaAnim.SetTrigger("TriggarFala");
    }
}
