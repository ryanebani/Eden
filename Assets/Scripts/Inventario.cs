using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public bool[] cheio;
    public GameObject[] slots;
    private Animator anim;
    public GameObject grid;
    public bool fechado;
    //public GameObject cancelar;
    

    public void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        fechado = true;
    }
    public void Update()
    {
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

    public void RemoverItem(GameObject slotRemov)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == slotRemov)
            {
                cheio[i] = false;
                slots[i].gameObject.SetActive(false);
                slots[i].GetComponent<Slots>().Item = null;
                break;
            }
        }
    }

    public void Selecionar(GameObject slotSelec)
    {
        
        for(int i = 0; i < slots.Length; i++)
        {
            
            if (slots[i] != slotSelec)
            {
                slots[i].GetComponent<Slots>().clicado = false;
            }

            if (slots[i] == slotSelec)
            {
                slotSelec.GetComponent<Slots>().clicado = true;
                Debug.Log(slots[i]);
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
