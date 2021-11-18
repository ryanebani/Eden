using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class AlvoMovendo : MonoBehaviour
{
    [SerializeField] Transform destinoTransform;
    Interagir jogador;
    ObjInt obj;

    Vector3 destino;
    Vector2 ponto;

    public bool negarItem;
    public bool receberItem;
    public bool chao;
    public bool Item;
    public bool NPC;
    public bool direita;
    public UnityEvent CheckEntregarItem;
    public UnityEvent OnCheguei;
    

    private void Start()
    {
        destino = destinoTransform.position;
        jogador = FindObjectOfType<Interagir>();
        obj = GetComponent<ObjInt>();
    }

    public void MouseUp()
    {
        if (Interagir.podeAndar)
        {
            Interagir.paraOndeVou = gameObject.name;
            negarItem = false;
        }
        
       Inventario.fecharIventario = true;
        
    }
    
    private void Update()
    {
        if (Interagir.paraOndeVou == gameObject.name && DialogoController.podeClickar)
        {
            jogador.Andar(destino, chao);            
            if (jogador.posJogador.position.x == destino.x && chao == false)
            {                
                if (destino.x < transform.position.x)
                {
                    Interagir.olharDireita = true;
                }
                else
                {
                    Interagir.olharDireita = false;
                }

                //ler primeiro o entregar item
                //dps que faz o resto

                CheckEntregarItem?.Invoke();

                if (negarItem == false)
                {
                    OnCheguei?.Invoke();
                    if (Item == false)
                    {
                        if (NPC)
                        {
                            jogador.OffSet();
                        }
                        else
                        {
                            obj.RandomIdle();
                        }
                        Interagir.paraOndeVou = "";
                    }
                }
                else
                {
                    jogador.PodeIdle("Acho que não é isso");
                    jogador.OffSet();
                    Interagir.itemNaMao = false;
                }

            }
        }

    }

}
