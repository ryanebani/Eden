using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicacao : MonoBehaviour
{
    public static bool indicar;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(indicar == true)
        {
            GetComponent<Animator>().SetTrigger("Indicar");
            indicar = false;
        }
    }
}
