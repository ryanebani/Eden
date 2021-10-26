using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    [SerializeField] Text textoSelecao;

    public GameObject[] slots;
    public GameObject grid;
    //public GameObject cancelar;

    public bool[] cheio;
    public bool fechado;

    Animator anim;        

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
            //cancelar.SetActive(false);
        }
        else
        {
            anim.SetBool("Fechar", false);
            //cancelar.SetActive(true);
        }
    }
    public void AdicionarItem(ItemOS _item, GameObject destruir)
    {
        AbrirMenu();
        for (int i = 0; i < slots.Length; i++)
        {
            if (cheio[i] == false)
            {
                cheio[i] = true;
                slots[i].gameObject.GetComponent<Slots>().Item = _item;
                slots[i].gameObject.SetActive(true);
                Destroy(destruir);
                break;
            }
        }
    }

    public void RemoverItem()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].GetComponent<Slots>().clicado)
            {
                slots[i].GetComponent<Slots>().clicado = false;
                cheio[i] = false;
                slots[i].gameObject.SetActive(false);
                slots[i].GetComponent<Slots>().Item = null;
                textoSelecao.text = null;
                break;
                
            }
        }
    }

    /*public void Selecionar(GameObject slotSelec)
    {
        
        for(int i = 0; i < slots.Length; i++)
        {
            
            if (slots[i] == slotSelec)
            {
                slots[i].GetComponent<Slots>().clicado = true;
                Interagir.itemSelecionado = slotSelec.name;
            }
        }
    }*/
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
