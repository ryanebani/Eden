using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CaixaIdle : MonoBehaviour
{
    [SerializeField] TextMeshPro textoMesh;
    [SerializeField] bool abel;
    static public bool cancelarTextoAbel;
    Animator caixaAnim;
    SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        caixaAnim = GetComponent<Animator>();
        sprite.enabled = false;
    }

    void Update()
    { 
        if(cancelarTextoAbel == true && abel)
        {
            ResetarTexto();
            cancelarTextoAbel = false;          
        }

    }

    public void ResetarTexto()
    {
        sprite.enabled = false;
        textoMesh.text = "";
    }

    public void SetFala(string idle)
    {
        sprite.enabled = true;
        cancelarTextoAbel = false;
        textoMesh.text = idle;
        caixaAnim.SetTrigger("TriggarFala");
    }

    
    
}