using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogoController : MonoBehaviour
{
    public GameObject painelDeDialogo;

    public Text falaNPC;

    public GameObject painelDeNome;

    public Text nomeNPC;

    public GameObject resposta;

    public Image sprite;

    private bool falaAtiva = false;

    FalaNPC falas;

    Touch touch;

    public bool mask;

    bool repetiu;

    int index = 0;

    Personagem jogador;
    Personagem NPC;


    void Start()
    {
       
    }

    
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && falaAtiva)
            {
                if (falas.sequencia == null)
                {
                    if (falas.respostas.Length > 0)
                    {
                        MostarRespostas();
                    }
                    else
                    {
                        falaAtiva = false;
                        painelDeNome.SetActive(false);
                        nomeNPC.gameObject.SetActive(false);
                        painelDeDialogo.SetActive(false);
                        falaNPC.gameObject.SetActive(false);
                        sprite.gameObject.SetActive(false);
                        repetiu = false;
                        jogador = null;
                        NPC = null;
                        Interagir.podeAndar = true;
                        if (falas.acao)
                            falas.OnFinalDialogo?.Invoke();
                    }
                }
                else
                {
                    if (index < falas.sequencia.sequencia.Length)
                    {
                        falaNPC.text = falas.sequencia.sequencia[index];
                        if (falas.sequencia.npcFalando[index])
                        {
                            sprite.sprite = falas.NPC.sprite;
                            nomeNPC.text = falas.NPC.nome;
                            falaNPC.color = falas.NPC.cor;
                        }
                        else
                        {
                            sprite.sprite = falas.jogador.sprite;
                            nomeNPC.text = falas.jogador.nome;
                            falaNPC.color = falas.jogador.cor;
                        }
                        index++;
                    }
                    else
                    {
                        index = 0;
                        if (falas.sequencia.proximaFala != null)
                        {
                            ProximaFala(falas.sequencia.proximaFala);
                        }
                        else
                        {
                            Interagir.podeAndar = true;
                            falaAtiva = false;
                            painelDeDialogo.SetActive(false);
                            falaNPC.gameObject.SetActive(false);
                            painelDeNome.SetActive(false);
                            nomeNPC.gameObject.SetActive(false);
                            sprite.gameObject.SetActive(false);
                            jogador = null;
                            NPC = null;
                            repetiu = false;
                            if (falas.acao)
                                falas.OnFinalDialogo?.Invoke();
                        }

                    }

                }
            }
        }
    }

    void MostarRespostas()
    {
        painelDeNome.SetActive(false);
        nomeNPC.gameObject.SetActive(false);
        sprite.sprite = falas.jogador.sprite;
        if (falas.falaNode != "")
        {
            falaNPC.text = falas.falaNode;
            if (falas.NPCNode)
                falaNPC.color = falas.NPC.cor;
            else
                falaNPC.color = falas.jogador.cor;
        }
        //falaNPC.gameObject.SetActive(false);
        falaAtiva = false;

        if (!mask)
        {
            for (int i = 0; i < falas.respostas.Length - 1; i++)
            {
                GameObject tempResposta = Instantiate(resposta, painelDeDialogo.transform) as GameObject;
                tempResposta.GetComponent<Text>().text = falas.respostas[i].resposta;
                tempResposta.GetComponent<AnswerButton>().Setup(falas.respostas[i]);
            }
        }
        else
        {
            for (int i = 0; i < falas.respostas.Length; i++)
            {
                GameObject tempResposta = Instantiate(resposta, painelDeDialogo.transform) as GameObject;
                tempResposta.GetComponent<Text>().text = falas.respostas[i].resposta;
                tempResposta.GetComponent<AnswerButton>().Setup(falas.respostas[i]);
            }
        }
    }

    public void ProximaFala(FalaNPC fala)
    {
        falaNPC.text = "";
        Interagir.podeAndar = false;
        falas = fala;

        LimparRespostas();

        /*
        if(jogador == null)
        {
            jogador = falas.jogador;
            NPC = falas.NPC;
        }
        else
        {
            falas.jogador = jogador;
            falas.NPC = NPC;
        }
        */

        falaAtiva = true;
        painelDeNome.SetActive(true);
        nomeNPC.gameObject.SetActive(true);
        painelDeDialogo.SetActive(true);
        falaNPC.gameObject.SetActive(true);
        sprite.gameObject.SetActive(true);

        if (falas.recomecar && repetiu)
        {
            MostarRespostas();
        }
        else
        {
            if (falas.recomecar)
            {
                repetiu = true;
            }
            falaNPC.text = falas.fala;

            if (falas.npcFalando)
            {
                sprite.sprite = falas.NPC.sprite;
                nomeNPC.text = falas.NPC.nome;
                falaNPC.color = falas.NPC.cor;
            }
            else
            {
                sprite.sprite = falas.jogador.sprite;
                nomeNPC.text = falas.jogador.nome;
                falaNPC.color = falas.jogador.cor;
            }
        }
        
    }

    void LimparRespostas()
    {
        AnswerButton[] buttons = FindObjectsOfType<AnswerButton>();
        foreach(AnswerButton button in buttons)
        {
            Destroy(button.gameObject);
        }
    }
}
