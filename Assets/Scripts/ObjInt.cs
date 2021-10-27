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

    public GameObject painel;
    public TextMeshProUGUI falaObj;
   
    
    public void OnValidate()
    {
        gameObject.name = ObjOS.nomeObj;
        falas = ObjOS.falas;
    }
        
    void Update() 
    {
        if (podeObservar)
        {
            falaObj.text = ObjOS.falas;
            painel.SetActive(true);
            podeObservar = false;
        }
    }

    public void PodeObservar()
    {
        podeObservar = true;
    }
}
