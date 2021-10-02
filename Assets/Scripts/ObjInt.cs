using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInt : MonoBehaviour
{
    public ObjIntOS ObjOS;
    public string falas;
   
    
    public void OnValidate()
    {
        gameObject.name = ObjOS.nomeObj;
        falas = ObjOS.falas;

    }
        
    void Update() 
    { 
       
    }
}
