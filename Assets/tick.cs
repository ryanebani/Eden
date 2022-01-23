using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tick : MonoBehaviour
{


    void Start()
    {
        StartCoroutine(timer());
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(5);
        Tick();
        StartCoroutine(timer());
        
    }
    void Tick()
    {
        Debug.Log("tick");
    }
}
