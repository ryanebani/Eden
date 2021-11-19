using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class NPCOS : ScriptableObject
{
    public string nomeNPC;
    public GameObject prefab;    
    public AudioSource audioSource;
    public AudioClip[] voz;
    public string[] falasIdle;
    public string[] falasIdleMascara;
}
