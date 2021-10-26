using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dialogo : MonoBehaviour
{
    public FalaNPC[] falas = new FalaNPC[4];

    public bool dialogoConcluido = false;
    private bool dialogoConcluidoMascara = false;

    DialogoController dialogoController;

    public bool mascara;

    public UnityEvent OnChegueiNPC;

    void Start()
    {
        dialogoController = FindObjectOfType<DialogoController>();
    }

    
    void Update()
    {
        
    }

    public void Ativar()
    {
        DialogoController.dialogo = GetComponent<Dialogo>();

        if (!mascara)
        {
            if (!dialogoConcluido)
            {
                dialogoController.ProximaFala(falas[0]);
            }
            else
            {
                dialogoController.ProximaFala(falas[1]);
            }
            dialogoConcluido = true;
        }
        else
        {
            if (!dialogoConcluidoMascara)
            {
                dialogoController.ProximaFala(falas[2]);
            }
            else
            {
                dialogoController.ProximaFala(falas[3]);
            }
            dialogoConcluidoMascara = true;

        }


    }
}
