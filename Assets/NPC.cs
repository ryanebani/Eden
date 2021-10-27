using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPC : MonoBehaviour
{
    public ItemOS item;
    public string chave;

    private bool itemDesejado;
    private bool infoDesejada;

    public Inventario inventario;
    private DialogoController DC;
    private Dialogo D;

    void Start()
    {
        DC = FindObjectOfType<DialogoController>();
        D = GetComponent<Dialogo>();
    }

    // Update is called once per frame
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

    public void darItem()
    {
        if (itemDesejado)
        {
            inventario.RemoverItem();
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
            DC.entregaItem = true;
            inventario.RemoverItem();
        }
    }


    public void InfoPorInfo()
    {
        if (infoDesejada)
        {
            DC.entregaItem = true;
        }
    }

    public void InfoPorItem()
    {
        if (infoDesejada)
        inventario.AdicionarItem(item, gameObject);
    }
}
