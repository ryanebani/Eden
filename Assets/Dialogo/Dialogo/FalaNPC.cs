using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FalaNPC : ScriptableObject
{
    public string fala;

    public Resposta[] respostas;

    public Sequencia sequencia;

    public bool npcFalando;

    public string falaNode;

    public Personagem jogador;
    public Personagem NPC;

    public bool recomecar;
    public bool NPCNode;
}
