using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public ItemOS Item;   
    [SerializeField] GameObject selecionado;    
    [SerializeField] Text Nome;
    [SerializeField] Text Descricao;
    [SerializeField] Image Icone;
    public bool clicado;    

    public void Update()
    {
        if (Item != null)
        {
            Icone.enabled = true;
            Icone.sprite = Item.icone;            
        }
        else
        {
            Icone.enabled = false;
            Icone.sprite = null;
        }

        if (clicado == true)
        {
            selecionado.SetActive(true);            
            Nome.text = Item.nome;
            Descricao.text = Item.descricao;
        }
        else
        {
            selecionado.SetActive(false);            
            Nome.text = "";
            Descricao.text = "";
        }
    }

    /*public void Selecionar()
    {

        ligado = !ligado;

        

    }*/
}
