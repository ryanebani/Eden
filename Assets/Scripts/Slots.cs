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

    }

    public void Selecionar(bool ligado)
    {
 
        if (ligado == true)
        {
            selecionado.SetActive(true);
            clicado = true;
            Nome.text = Item.nome;
            Descricao.text = Item.descricao;
        }
        else
        {
            selecionado.SetActive(false);
            clicado = false;
            Nome.text = "";
            Descricao.text = ""; 
        }          

    }
}
