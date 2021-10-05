using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Sequencia : ScriptableObject
{
    public string[] sequencia;
    public bool[] npcFalando;

    public FalaNPC proximaFala;
}
