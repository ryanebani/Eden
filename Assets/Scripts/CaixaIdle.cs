using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CaixaIdle : MonoBehaviour
{
    [SerializeField] TextMeshPro textoMesh;
    [SerializeField] Transform alvo;

    static public bool textoAbel;
    public bool abel;
    public Animator caixaAnim;       
    public string fala;

    void Start()
    {
        caixaAnim = GetComponent<Animator>();
        textoAbel = true;
    }

    void Update()
    { 
        if(abel == true && textoAbel == false)
        {
            caixaAnim.SetTrigger("CancelarFala");
            textoAbel = true;
        }

        textoMesh.text = fala;
        if (abel == true) { transform.position = alvo.position + new Vector3(0, 3, 0); }
    }

    public void ResetarTexto()
    {
        fala = "";        
    }
}