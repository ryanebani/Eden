using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionsNPC : MonoBehaviour
{
    [SerializeField] Animator animator;
    Inventario inventario;
    Dialogo dialogo;
    AlvoMovendo alvo;
    Fade fade;    
    bool itemDesejado;

    public bool semDialogo;
    public string chave;
    public string chaveMascara;
    public ItemOS item;


    void Start()
    {
        
        inventario = FindObjectOfType<Inventario>();
        fade = GetComponent<Fade>();
        if(semDialogo == false)
        {
            dialogo = GetComponent<Dialogo>();
        }
       
        alvo = GetComponent<AlvoMovendo>();
    }

   
    void Update()
    {
        //DetectarItem();
    }

    public void SetarChave(string chave)
    {
        this.chave = chave;
    }

    public void SetarChaveMascara(string chaveMascara)
    {
        this.chaveMascara = chaveMascara;
    }

    public void SetarItem(ItemOS item)
    {
        this.item = item;
    }

    public void EntregarItem(bool receber)
    {

        if (Interagir.itemNaMao)
        {
            if (receber && Interagir.itemSelecionado == chave)
            {
                ReceberItem();
                Interagir.itemNaMao = false;
            }

            else if (Dialogo.mascara == false && Interagir.itemSelecionado == chave)
               
            {
                inventario.RemoverItem();
                dialogo.ProximaQuestSemMascara();
                Interagir.itemNaMao = false;
            }
            else if (Dialogo.mascara == true && Interagir.itemSelecionado == chaveMascara)

            {
                inventario.RemoverItem();
                dialogo.ProximaQuestComMascara();
                Interagir.itemNaMao = false;
            }

            else
            {
                alvo.negarItem = true;
            }
        }
    }

    public void ReceberItem()
    {
        inventario.AdicionarItem(item);
    }

    /* public void InfoObtida()
    {
        infoDesejada = true;
    }

    public void darItem(bool precisaFade)
    {
        
        if (itemDesejado)
        {
            inventario.RemoverItem();
            dialogo.ProximaQuest();
            Debug.Log(Interagir.itemSelecionado);
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
    

    public void ItemPorInfo()
    {
        if (itemDesejado)
        {
            //liberaResposta = true;
            inventario.RemoverItem();
        }
    }


    public void InfoPorInfo()
    {
        if (infoDesejada)
        {
            liberaResposta = true;
        }
    }

    public void InfoPorItem()
    {
        if (infoDesejada)
            inventario.AdicionarItem(item, gameObject);
    }*/


    public void TriggarAnimacao(string trigger)
    {
        animator.SetTrigger(trigger);
    }
}
