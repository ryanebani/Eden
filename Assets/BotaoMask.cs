using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoMask : MonoBehaviour
{
    [SerializeField]Image filho;
  
    void Update()
    {
        if(Dialogo.mascara == true)
        {
            filho.enabled = true;
        }else
        {
            filho.enabled = false;
            
        }

    }
}
