using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasItens : MonoBehaviour
{
    static public bool CanvasAberto;
    [SerializeField] GameObject gameObj;
    Inventario inventario;
    public string chave;
    public ItemOS item;

    private void OnEnable()
    {
        CanvasAberto = true;
    }

    private void OnDisable()
    {
        CanvasAberto = false;
    }
    void Start()
    {
        inventario = FindObjectOfType<Inventario>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EntregarItem()
    {
        if (Interagir.itemNaMao == true)
        {
            if (Interagir.itemSelecionado == chave)
            {
                inventario.RemoverItem();
                //dialogo.ProximaQuest();
                Interagir.itemNaMao = false;
                if (gameObj)
                {
                    gameObj.SetActive(true);
                }
            }
            else
            {
                //alvo.negarItem = true;
            }
        }
    }

    public void ReceberItem()
    {
        inventario.AdicionarItem(item);
    }
}
