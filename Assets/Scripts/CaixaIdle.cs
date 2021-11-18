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

    void Start()
    {
        caixaAnim = GetComponent<Animator>();
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
        textoMesh.text = "";
    }

    public void SetFala(string idle)
    {
        cancelarTextoAbel = false;
        textoMesh.text = idle;
        caixaAnim.SetTrigger("TriggarFala");
    }

    
    
}