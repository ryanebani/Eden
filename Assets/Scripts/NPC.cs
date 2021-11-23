using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPC : MonoBehaviour
{
    [SerializeField] CaixaIdle caixaIdle;

    [SerializeField] NPCOS npc;
    string[] falasIdleNPC;
    string[] falasIdleMascara;
    public bool idle;
    public bool idleMascara;
    int indice;
    public bool animar;

    [SerializeField]
    public Animator sinalInfo;
    
    void Start()
    {
        falasIdleNPC = npc.falasIdle;
        falasIdleMascara = npc.falasIdleMascara;
    }

    void Update()
    {
        if(animar)
            sinalInfo.SetBool("ativar", true);
        else
            sinalInfo.SetBool("ativar", false);
    }

    public void OnValidate()
    {
        if (npc != null)
        {
            gameObject.name = npc.nomeNPC;
        }
    }

    public void PodeIdleNPC()
    {
        if (Dialogo.mascara == false)
        {
            indice = Random.Range(0, falasIdleNPC.Length);
            for (int i = 0; i < falasIdleNPC.Length; i++)
            {
                if (indice == i)
                {
                    caixaIdle.SetFala(falasIdleNPC[i]);
                    break;
                }
            }
        }
        else
        {
            indice = Random.Range(0, falasIdleMascara.Length);
            for (int i = 0; i < falasIdleMascara.Length; i++)
            {
                if (indice == i)
                {
                    caixaIdle.SetFala(falasIdleMascara[i]);
                    break;
                }
            }
        }


       
    }

    public void LigarIdle(bool ligar)
    {
        idle = ligar;
    }

    public void LigarIdleMascara(bool ligar)
    {
        idleMascara = ligar;
    }
}
