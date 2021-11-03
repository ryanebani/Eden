using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class NPCOS : ScriptableObject
{
    public string nomeNPC;
    public string[] falasIdle;
    public Sprite spriteNPC;    
    public Animator animator;
    public AudioSource voz;
}
