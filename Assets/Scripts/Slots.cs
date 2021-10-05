using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public ItemOS Item;   
    [SerializeField] GameObject selecionado;
    [SerializeField] Text textNome;
    [SerializeField] Image Icone;
    public bool clicado;    

    public void Update()
    {
        if (Item != null)
        {
            Icone.sprite = Item.icone;
            Icone.enabled = true;                       
        }
        else
        {
            Icone.enabled = false;            
        }
        
        if (Interagir.itemSelecionado == Item.nome)
        {
            clicado = true;
            Debug.Log(Item.nome + " 1 " + textNome.text);
            selecionado.SetActive(true);            
            textNome.text = Item.nome;
            Debug.Log(Item.nome + " 2 " + textNome.text);
            
        }
        else
        {
            selecionado.SetActive(false);
            clicado = false;
            
        }
    }

    public void Selecao()
    {
        Interagir.itemSelecionado = Item.nome;
        
    }
}
