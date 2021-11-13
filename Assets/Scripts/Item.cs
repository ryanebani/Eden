using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemOS item;
    Inventario inventario;
    bool podeAdicionar;
    SpriteRenderer render;

    public void OnValidate()
    {
        if (item != null)
        {
            gameObject.name = item.nome;
            render = GetComponent<SpriteRenderer>();
            render.sprite = item.icone;
        }
    }

    public void Start()
    {
        inventario = GameObject.FindObjectOfType<Inventario>();
        render = GetComponent<SpriteRenderer>();
        render.sprite = item.icone;
    }

    private void Update()
    {
        if (podeAdicionar)
        {
            inventario.AdicionarItem(item, gameObject);
            podeAdicionar = false;
        }
    }

    public void PodeAdicionar()
    {
        podeAdicionar = true;
    }
}
