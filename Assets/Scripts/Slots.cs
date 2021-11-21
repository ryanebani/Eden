using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public ItemOS Item;
    public string nome;
    [SerializeField] GameObject selecionado;
    Image icone;
    Inventario inventario;
    public bool clicado = false;

    public void Start()
    {
       inventario = GetComponentInParent<Inventario>();
    }
    public void Update()
    {
        icone = gameObject.GetComponent<Image>();
        if (Item != null)
        {
            icone.sprite = Item.icone;
            icone.enabled = true;
            nome = Item.nome;
        }
        else
        {
            icone.enabled = false;            
        }

        if (clicado)
        {
            selecionado.SetActive(true);
        }
        else
        {
            selecionado.SetActive(false);
        }

        if (clicado == true && inventario.textoSelecao.text != nome)
        {
            clicado = false;     
            //Inventario.itemNaMao = true;
        }
        /*else
        {
            selecionado.SetActive(false);
            clicado = false;
            //Inventario.itemNaMao = false;
        }*/
                
    }

    public void SelecionarParaQuest()
    {
        clicado = true;
        inventario.textoSelecao.text = nome;
    }
    
    public void Selecao()
    {
        clicado = !clicado;
        inventario.textoSelecao.text = nome;

        if (clicado == false)
        {
            inventario.textoSelecao.text = "";
        }
    }

    public void Ligar(bool ligar)
    {
        gameObject.SetActive(ligar);
    }
}
