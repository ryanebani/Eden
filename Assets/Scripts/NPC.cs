using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPC : MonoBehaviour
{
    [SerializeField] CaixaIdle caixaIdle;

    public NPCOS npc;
    public bool idle;
    public string[] falasIdleNPC;

    int indice;
    
    void Start()
    {

    }

    void Update()
    {

    }

    public void OnValidate()
    {
        if (npc != null)
        {
            falasIdleNPC = npc.falasIdle;
            gameObject.name = npc.nomeNPC;
        }
    }

    public void PodeIdleNPC()
    {
        CaixaIdle.textoAbel = true;
        RandomFala();
        for (int i = 0; i < falasIdleNPC.Length; i++)
        {
            if (indice == i)
            {
                caixaIdle.fala = falasIdleNPC[i];
                break;
            }
        }
        caixaIdle.caixaAnim.SetTrigger("TriggarFala");
    }

    public void RandomFala()
    {
        indice = Random.Range(0, falasIdleNPC.Length);
    }
}
