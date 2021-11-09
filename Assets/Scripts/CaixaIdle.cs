using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CaixaIdle : MonoBehaviour
{
    [SerializeField] TextMeshPro textoMesh;
    [SerializeField] bool abel;
    static public bool textoAbel;
    Vector3 euler;
    Transform pai;
    Transform myTransform;
    Animator caixaAnim;

    void Start()
    {
        caixaAnim = GetComponent<Animator>();
        euler = new Vector3(0, -180, 0);
        myTransform = GetComponent<Transform>();
        textoAbel = true;        
    }

    void Update()
    { 
        if(textoAbel == false && abel)
        {
            gameObject.SetActive(false);
            textoAbel = true;
        }

    }
    
    public void SetFala(string idle)
    {
        textoMesh.text = idle;
        caixaAnim.SetTrigger("TriggarFala");
    }

    public void ResetarTexto()
    {
        gameObject.SetActive(false);
        textoAbel = false;
    }

    public void LigarTexto()
    {
        /*if(pai.eulerAngles == euler)
        {
            myTransform.eulerAngles = new Vector3 (0,-180,0);
        }*/
        textoAbel = true;
        gameObject.SetActive(true);
    }
}