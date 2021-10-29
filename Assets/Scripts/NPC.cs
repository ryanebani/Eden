using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPC : MonoBehaviour
{
    public NPCOS npc;

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
            gameObject.name = npc.nomeNPC;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = npc.spriteNPC;
        }
    }

}
