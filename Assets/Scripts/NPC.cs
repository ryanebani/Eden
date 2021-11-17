using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPC : MonoBehaviour
{
    [SerializeField] CaixaIdle caixaIdle;

    [SerializeField] NPCOS npc;
    string[] falasIdleNPC;
    public bool idle;
    int indice;

    [SerializeField]
    public Animator sinalInfo;
    
    void Start()
    {
        falasIdleNPC = npc.falasIdle;
    }

    void Update()
    {

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
        caixaIdle.LigarTexto();
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


}
