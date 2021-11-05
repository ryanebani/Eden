using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dialogo : MonoBehaviour
{
    [SerializeField] NPC npc;

    public FalaNPC[] falasSemMascara = new FalaNPC[2];
    public FalaNPC[] falasComMascara = new FalaNPC[2];
    public UnityEvent OnFinalDialogo;

    public bool dialogoConcluido = false;
    public bool mascara;

    public FalaNPC[] falaQuestsSemMascara;
    public FalaNPC[] falaQuestsComMascara;
    public bool acabouAsQuests;

    bool dialogoConcluidoMascara = false;
    DialogoController dialogoController;
    
    Dictionary<FalaNPC, bool> questsComMascara = new Dictionary<FalaNPC, bool>();
    Dictionary<FalaNPC, bool> questsSemMascara = new Dictionary<FalaNPC, bool>();

    bool podeProximaQuest;


    void Start()
    {
        

        for(int i = 0; i < falaQuestsComMascara.Length; i++)
        {
            questsComMascara.Add(falaQuestsComMascara[i], false);
        }

        for (int i = 0; i < falaQuestsSemMascara.Length; i++)
        {
            questsSemMascara.Add(falaQuestsSemMascara[i], false);
        }

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
            podeProximaQuest = true;
                if (!mascara)
                {
                    if (questsSemMascara.ContainsValue(true))
                    {
                        foreach(KeyValuePair<FalaNPC, bool> v in questsSemMascara)
                        {
                            if(v.Value)
                            {
                                dialogoController.ProximaFala(v.Key);
                            }
                        }
                    }
                    else
                    {
                        if (!dialogoConcluido)
                        {
                            dialogoController.ProximaFala(falasSemMascara[0]);
                        }
                        else
                        {
                            dialogoController.ProximaFala(falasSemMascara[1]);
                        }
                        dialogoConcluido = true;
                    }
                }
                else
                {
                    if (questsComMascara.ContainsValue(true))
                    {
                        foreach (KeyValuePair<FalaNPC, bool> v in questsComMascara)
                        {
                            if (v.Value)
                            {
                                dialogoController.ProximaFala(v.Key);
                            }
                        }
                    }
                    else
                    {
                        if (!dialogoConcluidoMascara)
                        {
                            dialogoController.ProximaFala(falasComMascara[0]);
                        }
                        else
                        {
                            dialogoController.ProximaFala(falasComMascara[1]);
                        }
                        dialogoConcluidoMascara = true;
                    }

                }
            }

        
    }

    public void ProximaQuest()
    {
        if (mascara)
            ProximaQuestComMascara();
        else
            ProximaQuestSemMascara();
    }
    public void ProximaQuestSemMascara()
    {
        if (podeProximaQuest)
        {
            podeProximaQuest = false;
            if (!questsSemMascara.ContainsValue(true))
            {
                questsSemMascara[falaQuestsSemMascara[0]] = true;
            }
            else
            {
                for (int i = 0; i < falaQuestsSemMascara.Length; i++)
                {
                    if (questsSemMascara[falaQuestsSemMascara[i]] == true)
                    {
                        questsSemMascara[falaQuestsSemMascara[i]] = false;
                        if (i == falaQuestsSemMascara.Length - 1)
                        {
                            npc.idle = true;
                        }
                        else
                            questsSemMascara[falaQuestsSemMascara[i + 1]] = true;
                        break;
                    }
                }
            }
        }
    }

    public void ProximaQuestComMascara()
    {
        if (podeProximaQuest)
        {
            podeProximaQuest = false;
            if (!questsComMascara.ContainsValue(true))
            {
                questsComMascara[falaQuestsComMascara[0]] = true;
            }
            else
            {
                for (int i = 0; i < falaQuestsComMascara.Length; i++)
                {
                    if (questsComMascara[falaQuestsComMascara[i]] == true)
                    {
                        questsComMascara[falaQuestsComMascara[i]] = false;
                        if (i == falaQuestsComMascara.Length - 1)
                        {
                            npc.idle = true;
                        }
                        else
                            questsComMascara[falaQuestsComMascara[i + 1]] = true;
                        break;
                    }
                }
            }
        }
    }

}
