using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    static public bool fecharIventario;

    [SerializeField] Slots[] slots;    
    //[SerializeField] GameObject grid;

    bool fechado;
    Animator anim;

    public Text textoSelecao;
    public bool[] cheio;
    AudioSource som;
        
    //static public bool itemNaMao;

    public void Start()
    {
        som = GetComponent<AudioSource>();
        anim = gameObject.GetComponent<Animator>();
        fechado = true;
    }
    public void Update()
    {
        //textoSelecao.text = Interagir.itemSelecionado;

        if (fecharIventario)
        {
            FecharMenu();
            fecharIventario = false;

        }

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
        som.PlayOneShot(som.clip);
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
                slots[i].Ligar(false);
                slots[i].Item = null;
                Interagir.itemSelecionado = null;
                break;    
            }
        }
        FecharMenu();
    }
       

    public void MenuToggle()
    {
        fechado = !fechado;
    }

    public void FecharMenu()
    {
        fechado = true;
        textoSelecao.text = "";
        foreach (var slot in slots)
        {
            slot.clicado = false;
        }
    }

    public void AbrirMenu()
    { 
        fechado = false;
    }

    


}
