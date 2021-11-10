using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CaixaIdle : MonoBehaviour
{
    [SerializeField] TextMeshPro textoMesh;
    [SerializeField] bool abel;
    static public bool cancelarTextoAbel;
    Vector3 euler;
    Transform pai;
    Transform myTransform;
    Animator caixaAnim;

    void Awake()
    {
        caixaAnim = GetComponent<Animator>();
        euler = new Vector3(0, -180, 0);
        myTransform = GetComponent<Transform>();
        cancelarTextoAbel = false;
    }
    void Start()
    {
           
    }

    void Update()
    { 
        if(cancelarTextoAbel == true && abel)
        {
            ResetarTexto();
            cancelarTextoAbel = false;          
        }

    }
    public void LigarTexto()
    {
        gameObject.SetActive(true);

    }

    public void ResetarTexto()
    {
        gameObject.SetActive(false);
    }

    public void SetFala(string idle)
    {
        cancelarTextoAbel = false;
        textoMesh.text = idle;
        caixaAnim.SetTrigger("TriggarFala");

    }

    
    
}