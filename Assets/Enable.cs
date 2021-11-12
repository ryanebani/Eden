using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable : MonoBehaviour
{
   void OnEnable()
   {
        Interagir.podeAndar = false;
   }

    void OnDisable()
    {
        Interagir.podeAndar = true;
    }
}
