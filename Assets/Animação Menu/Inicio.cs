using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class Inicio : MonoBehaviour
{
    public CinemachineVirtualCamera logo;
    public CinemachineVirtualCamera menu;


    void Start()
    {
        
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            logo.Priority = 0;
            menu.Priority = 1;
        }
    }
}
