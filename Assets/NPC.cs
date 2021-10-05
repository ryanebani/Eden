using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public ItemOS item;
    public string chave;
    public Inventario inventario;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (Interagir.itemSelecionado == chave)
        {
            inventario.RemoverItem();
            inventario.AdicionarItem(item, gameObject);

        }
    }
}
