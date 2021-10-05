using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogo : MonoBehaviour
{
    public FalaNPC[] falas = new FalaNPC[2];

    private bool dialogoConcluido = false;

    DialogoController dialogoController;
    
    void Start()
    {
        dialogoController = FindObjectOfType<DialogoController>();
    }

    
    void Update()
    {
        
    }

    public void Ativar()
    {
        
        if(!dialogoConcluido)
        {
            dialogoController.ProximaFala(falas[0]);
        }
        else
        {
            dialogoController.ProximaFala(falas[1]);
        }

        dialogoConcluido = true;
    }
}
