using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogoController : MonoBehaviour
{
    private bool tocarSom = true;
    private SorteiaSom som;

    public GameObject painelComTudo;
    public static bool podeClickar = true;

    public static Dialogo dialogo;

    public GameObject painelDeDialogo;

    public Text falaNPC;

    public GameObject painelDeNome;

    public Text nomeNPC;

    public GameObject resposta;

    public Image spriteNPC;

    public Image spritePlayer;

    public Image imagemCutscene;

    private bool falaAtiva = false;

    public FalaNPC falas;

    Touch touch;

    bool repetiu;

    int index = 0;

    int indexCutscene = 0;

    Cutscene cutscene;

    Personagem jogador;
    Personagem NPC;

    bool falaController;

    Color opaco = new Color(1, 1, 1, 1);
    Color transparente = new Color(1, 1, 1, 0.5f);

    List<FalaNPC> naoAtivarAcao = new List<FalaNPC>();

    private void Start()
    {
        som = GetComponent<SorteiaSom>();
    }

    void Awake()
    {
       
    }

    
    void Update()
    {
        if(dialogo != null)
        {
            if(dialogo.npc.idle)
            {
                podeClickar = true;
            }
        }
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && falaAtiva)
            {
                AcaoSequencial();
                if (falas.sequencia == null)
                {
                    if (falas.respostas.Length > 0)
                    {
                        MostrarRespostas();
                    }
                    else
                    {
                        if (falas.proximaQuest)
                            dialogo.ProximaQuest();
                        
                        falaAtiva = false;
                        painelComTudo.SetActive(false);
                        painelDeNome.SetActive(false);
                        nomeNPC.gameObject.SetActive(false);
                        painelDeDialogo.SetActive(false);
                        falaNPC.gameObject.SetActive(false);
                        spriteNPC.gameObject.SetActive(false);
                        spritePlayer.gameObject.SetActive(false);
                        repetiu = false;
                        jogador = null;
                        NPC = null;
                        Interagir.podeAndar = true;
                        podeClickar = true;
                        tocarSom = true;
                        imagemCutscene.gameObject.SetActive(false);
                        indexCutscene = 0;
                    }
                }
                else
                {
                    if(falas.sequencia.proximaCutscene.Length != falas.sequencia.sequencia.Length)
                    {
                        falas.sequencia.proximaCutscene = new bool[falas.sequencia.sequencia.Length];
                    }
                    
                    if (index < falas.sequencia.sequencia.Length)
                    {
                        if(falas.sequencia.proximaCutscene[index])
                        {
                            indexCutscene++;
                            Cutscene();
                        }

                        falaNPC.text = falas.sequencia.sequencia[index];
                        if (falas.sequencia.npcFalando[index])
                        {
                            spritePlayer.color = transparente;
                            spriteNPC.color = opaco;
                            nomeNPC.text = falas.NPC.nome;
                            falaNPC.color = falas.NPC.cor;
                        }
                        else
                        {
                            spritePlayer.color = opaco;
                            spriteNPC.color = transparente;
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
                            if (falas.proximaQuest)
                                dialogo.ProximaQuest();
                            
                            Interagir.podeAndar = true;
                            painelComTudo.SetActive(false);
                            falaAtiva = false;
                            painelDeDialogo.SetActive(false);
                            falaNPC.gameObject.SetActive(false);
                            painelDeNome.SetActive(false);
                            nomeNPC.gameObject.SetActive(false);
                            spriteNPC.gameObject.SetActive(false);
                            spritePlayer.gameObject.SetActive(false);
                            jogador = null;
                            NPC = null;
                            repetiu = false;
                            podeClickar = true;
                            tocarSom = true;
                            imagemCutscene.gameObject.SetActive(false);
                            indexCutscene = 0;
                        }

                    }

                }
            }
        }
    }

    void MostrarRespostas()
    {
        painelDeNome.SetActive(false);
        nomeNPC.gameObject.SetActive(false);
        spritePlayer.color = opaco;
        spriteNPC.color = transparente;
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
        if (!dialogo.liberaResposta)
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

        
        if(falas.jogador != null)
        {
            jogador = falas.jogador;
            NPC = falas.NPC;
        }
        else
        {
            falas.jogador = jogador;
            falas.NPC = NPC;
        }

       

        spriteNPC.sprite = falas.NPC.sprite;
        spritePlayer.sprite = falas.jogador.sprite;
        falaAtiva = true;
        painelDeNome.SetActive(true);
        painelComTudo.SetActive(true);
        nomeNPC.gameObject.SetActive(true);
        painelDeDialogo.SetActive(true);
        falaNPC.gameObject.SetActive(true);
        spriteNPC.gameObject.SetActive(true);
        spritePlayer.gameObject.SetActive(true);

        

        if (falas.proximaCutscene)
        {
            if (falas.cutscene != null)
            {
                imagemCutscene.gameObject.SetActive(true);
                cutscene = falas.cutscene;
                indexCutscene = 0;
            }
            else
            {
                indexCutscene++;
            }
            Cutscene();
        }
        

        if (tocarSom)
        {
            tocarSom = false;
            som.EscolherSom(NPC.clipes);
        }

        if (falas.recomecar && repetiu)
        {
            MostrarRespostas();
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
                spritePlayer.color = transparente;
                spriteNPC.color = opaco;
                nomeNPC.text = falas.NPC.nome;
                falaNPC.color = falas.NPC.cor;
            }
            else
            {
                spriteNPC.color = transparente;
                spritePlayer.color = opaco;
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

    bool ConferirAcao()
    {
        foreach(FalaNPC a in naoAtivarAcao)
        {
            if (a == falas)
                return false;
        }

        return true;
    }

    void Cutscene()
    {

            if (indexCutscene >= cutscene.imagens.Length)
            {
                imagemCutscene.gameObject.SetActive(false);
                indexCutscene = 0;
            }
            else
            {
                imagemCutscene.sprite = cutscene.imagens[indexCutscene];

            }

        
    }

    void AcaoSequencial()
    {
        if (falas.acaoSequencial && dialogo.temIndexSemMask && !Dialogo.mascara)
        {
            if (ConferirAcao())
            {
                dialogo.ueSemMask[dialogo.indexSemMask]?.Invoke();
                dialogo.indexSemMask++;
                naoAtivarAcao.Add(falas);
            }
        }
        else if (falas.acaoSequencial && dialogo.temIndexMask && Dialogo.mascara)
        {
            if (ConferirAcao())
            {
                dialogo.ueMask[dialogo.indexMask]?.Invoke();
                dialogo.indexMask++;
                naoAtivarAcao.Add(falas);
            }
        }
    }
}
