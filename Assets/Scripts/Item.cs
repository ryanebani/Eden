using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemOS item;
    bool podeAdicionar;

    SpriteRenderer render;
    [SerializeField] Inventario inventario;

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
        render = GetComponent<SpriteRenderer>();
        render.sprite = item.icone;
    }

    private void Update()
    {
        if (podeAdicionar)
        {
            inventario.AdicionarItem(item);
            gameObject.SetActive(false);
            podeAdicionar = false;
        }
    }

    public void PodeAdicionar()
    {
        podeAdicionar = true;
    }
}
