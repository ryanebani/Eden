using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionsNPC : MonoBehaviour
{
    public ItemOS item;
    public string chave;

    private bool itemDesejado;
    private bool infoDesejada;

    public Inventario inventario;
    private DialogoController DC;

    [SerializeField]
    private FunctionsNPC NPCAlheio;

    void Start()
    {
        DC = FindObjectOfType<DialogoController>();
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
        NPCAlheio.infoDesejada = true;
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
