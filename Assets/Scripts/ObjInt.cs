using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjInt : MonoBehaviour
{
    public ObjIntOS ObjOS;
    public string falas;

    bool podeObservar;

    public Text falaObj;
   
    
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
            podeObservar = false;
        }
    }

    public void PodeObservar()
    {
        podeObservar = true;
    }
}
