using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public ItemOS Item;   
    [SerializeField] GameObject selecionado;
    Image icone;
    public bool clicado = false;    


    public void Update()
    {
        icone = gameObject.GetComponent<Image>();
        if (Item != null)
        {
            icone.sprite = Item.icone;
            icone.enabled = true;                       
        }
        else
        {
            icone.enabled = false;            
        }


        if (clicado == true && Interagir.itemSelecionado == Item.nome)
        {
            selecionado.SetActive(true);
            Inventario.itemNaMao = true;
        }
        else
        {
            selecionado.SetActive(false);
            clicado = false;
            Inventario.itemNaMao = false;
        }
                
    }


    public void Selecao()
    {
        clicado = !clicado;
        Interagir.itemSelecionado = Item.nome;

        if (clicado == false)
        {
            Interagir.itemSelecionado = null;
        }
    }
}
