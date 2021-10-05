using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FalaNPC : ScriptableObject
{
    public string fala;

    public Resposta[] respostas;

    public Sequencia sequencia;

    public Color corPlayer;
    public Color corNPC;

    public bool npcFalando;
}
