using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dialogo : MonoBehaviour
{
    public NPC npc;
    public AlvoMovendo alvo;

    public FalaNPC[] falasSemMascara = new FalaNPC[2];
    public FalaNPC[] falasComMascara = new FalaNPC[2];

    public bool liberaResposta;
    public bool dialogoConcluido = false;
    public static bool mascara;

    public FalaNPC[] falaQuestsSemMascara;
    public FalaNPC[] falaQuestsComMascara;
    public bool acabouAsQuests;

    bool dialogoConcluidoMascara = false;
    DialogoController dialogoController;
    
    Dictionary<FalaNPC, bool> questsComMascara = new Dictionary<FalaNPC, bool>();
    Dictionary<FalaNPC, bool> questsSemMascara = new Dictionary<FalaNPC, bool>();
    
    public UnityEvent[] ueMask = new UnityEvent[0];
    public UnityEvent[] ueSemMask = new UnityEvent[0];
    public int indexMask = 0;
    public int indexSemMask = 0;
    public bool temIndexMask = true;
    public bool temIndexSemMask = true;

    private int contador = 0;
    [SerializeField]
    private int numQuest;

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

        npc = GetComponent<NPC>();
        alvo = GetComponent<AlvoMovendo>();
    }

    
    void Update()
    {
        if (mascara)
        {
            if (indexMask >= ueMask.Length)
            {
                temIndexMask = false;
            }
        }
        else
        {
            if (indexSemMask >= ueSemMask.Length)
            {
                temIndexSemMask = false;
            }
        }
    }

    public void Conversar()
    {
        DialogoController.dialogo = GetComponent<Dialogo>();

        if(alvo.negarItem == false)
        {
            if (mascara)
            {
                if (npc.idleMascara)
                {
                    npc.PodeIdleNPC();
                }
                else
                {
                    Ativar();
                }
            }
            else
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
        }       
    }

    public void Ativar()
    {

            if (DialogoController.podeClickar)
            {
                
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
        liberaResposta = false;
        if (mascara)
                ProximaQuestComMascara();
            else
                ProximaQuestSemMascara();
    }

    public void QuestsFeitas()
    {
        contador++;

        if (contador == numQuest)
        {
            if (mascara)
                ProximaQuestComMascara();
            else
                ProximaQuestSemMascara();

            contador = 0;
        }
    }

    public void novaInformacao()
    {
        liberaResposta = true;
        npc.sinalInfo.SetBool("ativar", true);
    }

    public void desativarSinal()
    {
        npc.sinalInfo.SetBool("ativar", false);
    }

    public void ProximaQuestSemMascara()
    {
        
            if (falaQuestsSemMascara.Length != 0)
            {
                
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
                            {
                                questsSemMascara[falaQuestsSemMascara[i + 1]] = true;
                                liberaResposta = false;
                            }
                            break;
                        }
                    }
                }
            }
            else
                npc.idle = true;
        
    }

    public void ProximaQuestComMascara()
    {
        
            if (falaQuestsComMascara.Length != 0)
            {
               
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
                                npc.idleMascara = true;
                            }
                            else
                            {
                                questsComMascara[falaQuestsComMascara[i + 1]] = true;
                                liberaResposta = false;
                            }
                            break;
                        }
                    }
                }
            }
            else
                npc.idleMascara = true;
        
    }

}
