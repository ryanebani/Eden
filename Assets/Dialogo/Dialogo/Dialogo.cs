using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dialogo : MonoBehaviour
{
    [SerializeField] NPC npc;    

    public FalaNPC[] falas = new FalaNPC[4];
    public UnityEvent OnFinalDialogo;

    public bool dialogoConcluido = false;
    public bool mascara;

    bool dialogoConcluidoMascara = false;
    DialogoController dialogoController;


    void Start()
    {
        dialogoController = FindObjectOfType<DialogoController>();
    }

    
    void Update()
    {
        
    }

    public void Conversar()
    {
        if (npc.idle)
        {
            npc.PodeIdleNPC();
        }
        else
        {
            Ativar();
        }

    }

    public void Ativar()
    {
            if (Inventario.itemNaMao == false)
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
}
