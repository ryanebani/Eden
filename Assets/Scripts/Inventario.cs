using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    [SerializeField] Text textoSelecao;
    [SerializeField] Slots[] slots;
    [SerializeField] GameObject grid;
    bool fechado;

    public bool[] cheio;
    Animator anim;
    static public bool itemNaMao;

    public void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        fechado = true;
    }
    public void Update()
    {
        textoSelecao.text = Interagir.itemSelecionado;

        if (fechado == true)
        {
            anim.SetBool("Fechar", true);
        }
        else
        {
            anim.SetBool("Fechar", false);
        }
    }
    public void AdicionarItem(ItemOS _item)
    {
        AbrirMenu();
        for (int i = 0; i < slots.Length; i++)
        {
            if (cheio[i] == false)
            {
                cheio[i] = true;
                slots[i].Item = _item;
                slots[i].Ligar(true);                              
                break;
            }
        }
        DialogoController.podeClickar = true;
    }

    public void RemoverItem()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].clicado)
            {
                slots[i].clicado = false;
                cheio[i] = false;
                slots[i].Ligar(true);
                slots[i].Item = null;
                Interagir.itemSelecionado = null;
                break;    
            }
        }
    }
       

    public void MenuToggle()
    {
        fechado = !fechado;
    }

    public void FecharMenu()
    {
        fechado = true;
    }

    public void AbrirMenu()
    {
        fechado = false;
    }



}
