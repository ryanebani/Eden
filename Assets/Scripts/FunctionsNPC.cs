using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionsNPC : MonoBehaviour
{
    public ItemOS item;
    public string chave;
    public Inventario inventario;

    private bool itemDesejado;
    private bool infoDesejada;
    private Animator animator;

    private Fade fade;
    private DialogoController DC;

    void Start()
    {
        DC = FindObjectOfType<DialogoController>();
        fade = GetComponent<Fade>();
        animator = GetComponentInChildren<Animator>();
    }

   
    void Update()
    {

    }

    private void detectarItemInfo()
    {
        if (Interagir.itemSelecionado == chave)
        {
            itemDesejado = true;
        }
    }

    private void OnMouseDown()
    {
        detectarItemInfo();
    }

    public void InfoObtida()
    {
        infoDesejada = true;
    }

    public void darItem(bool precisaFade)
    {
        if (itemDesejado)
        {
            inventario.RemoverItem();
            if (precisaFade)
            {
                fade.IniciarFade();
            }
        }
    }

    public void receberItem()
    {
        
        if (itemDesejado)
        {
            inventario.AdicionarItem(item, gameObject);
        }
    }

    public void ItemPorInfo()
    {
        if (itemDesejado)
        {
            DC.liberaResposta = true;
            inventario.RemoverItem();
        }
    }


    public void InfoPorInfo()
    {
        if (infoDesejada)
        {
            DC.liberaResposta = true;
        }
    }

    public void InfoPorItem()
    {
        if (infoDesejada)
            inventario.AdicionarItem(item, gameObject);
    }

    public void TriggarAnimacao(Animator animator)
    {
        animator.SetTrigger("BelaFeliz");
    }
}
