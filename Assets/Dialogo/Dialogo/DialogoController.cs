using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogoController : MonoBehaviour
{
    public float typingSpeed;

    public FalaNPC primeiraCut;
    public bool final;

    private bool tocarSom = true;
    private SorteiaSom som;
    Animator animDiag;
    public GameObject painelComTudo;
    public GameObject painelDeDialogo;
    public static bool podeClickar = true;

    public static Dialogo dialogo;

    public Text falaNPC;
    public Image nomeNPC;
    public Image nomeJogador;
    public Animator rumor;

    public GameObject resposta;

    public Image spriteNPC;
    public Image spritePlayer;

    public Image imagemCutscene;

    private bool falaAtiva = false;

    [HideInInspector]
    public FalaNPC falas;

    Touch touch;

    bool repetiu;

    int index = 0;

    int indexCutscene = 0;

    Cutscene cutscene;

    Personagem jogador;
    Personagem NPC;

    bool falaController;

    Color novaInformacao = new Color(0.5450981f, 0.9921569f, 1, 1);

    List<FalaNPC> naoAtivarAcao = new List<FalaNPC>();

    public Sprite abelMask;
    public Sprite nomeMask;
    private void Start()
    {
        som = GetComponent<SorteiaSom>();
        if(primeiraCut != null)
            ProximaFala(primeiraCut);
    }

    void Awake()
    {
        animDiag = painelComTudo.GetComponent<Animator>();
        //painelComTudo.SetActive(true);
    }

    
    void Update()
    {
        /*if (animDiag.GetCurrentAnimatorStateInfo(0).IsName("DialogoVazio"))
        {
            painelComTudo.SetActive(false);
        }*/

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

            if (touch.phase == TouchPhase.Began && falaAtiva && animDiag.GetCurrentAnimatorStateInfo(0).IsName("DialogoParado"))
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
                        painelComTudo.gameObject.GetComponent<Animator>().SetBool("Aberto", false); 
                        repetiu = false;
                        jogador = null;
                        NPC = null;
                        Interagir.podeAndar = true;
                        podeClickar = true;
                        tocarSom = true;
                        imagemCutscene.gameObject.SetActive(false);
                        indexCutscene = 0;
                        if (primeiraCut != null)
                            SceneManager.LoadScene("J1", LoadSceneMode.Single);
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
                        if(primeiraCut != null && index == 2 && !GetComponent<AudioSource>().isPlaying)
                        {
                            GetComponent<AudioSource>().Play();
                        }
                        if(falas.sequencia.proximaCutscene[index])
                        {
                            indexCutscene++;
                            Cutscene();
                        }
                        falaNPC.text = "";
                        StartCoroutine(TypeSentence(falas.sequencia.sequencia[index]));
                        if (falas.sequencia.npcFalando[index])
                        {
                            spritePlayer.gameObject.GetComponent<Animator>().SetBool("Falando", false);
                            spriteNPC.gameObject.GetComponent<Animator>().SetBool("Falando", true);
                            falaNPC.color = falas.NPC.cor;
                        }
                        else
                        {

                            spritePlayer.gameObject.GetComponent<Animator>().SetBool("Falando", true);
                            spriteNPC.gameObject.GetComponent<Animator>().SetBool("Falando", false);
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
                            painelComTudo.gameObject.GetComponent<Animator>().SetBool("Aberto", false);
                            falaAtiva = false;
                            jogador = null;
                            NPC = null;
                            repetiu = false;
                            podeClickar = true;
                            tocarSom = true;
                            imagemCutscene.gameObject.SetActive(false);
                            indexCutscene = 0;
                            if (primeiraCut != null && !final)
                                SceneManager.LoadScene("J1", LoadSceneMode.Single);
                            else if(primeiraCut != null && final)
                                SceneManager.LoadScene("Menu", LoadSceneMode.Single);
                        }

                    }

                }
            }
        }
    }

    void MostrarRespostas()
    {
        spritePlayer.gameObject.GetComponent<Animator>().SetBool("Falando", true);
        spriteNPC.gameObject.GetComponent<Animator>().SetBool("Falando", false);
        if (falas.falaNode != "")
        {
            falaNPC.text = falas.falaNode;
            if (falas.NPCNode)
                falaNPC.color = falas.NPC.cor;
            else
                falaNPC.color = falas.jogador.cor;
        }
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
                if(i == falas.respostas.Length - 1)
                {
                    tempResposta.GetComponent<Text>().color = novaInformacao;
                }
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

       

        
        falaAtiva = true;
        painelComTudo.SetActive(true);
        painelComTudo.gameObject.GetComponent<Animator>().SetBool("Aberto", true);

        if(!Dialogo.mascara)
        {
            spritePlayer.sprite = falas.jogador.sprite;
            nomeJogador.sprite = jogador.nome;
            nomeJogador.SetNativeSize();
        }
        else
        {
            spritePlayer.sprite = abelMask;
            nomeJogador.sprite = nomeMask;
            nomeJogador.SetNativeSize();
        }

        //Setagem NPC
        spriteNPC.sprite = falas.NPC.sprite;
        nomeNPC.sprite = NPC.nome;
        nomeNPC.SetNativeSize();

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
        

        if (tocarSom && NPC.clipes.Length != 0)
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
            falaNPC.text = "";
            StartCoroutine(TypeSentence(falas.fala));

            if (falas.npcFalando)
            {
                spritePlayer.gameObject.GetComponent<Animator>().SetBool("Falando", false);
                spriteNPC.gameObject.GetComponent<Animator>().SetBool("Falando", true);
                falaNPC.color = falas.NPC.cor;
            }
            else
            {
                spritePlayer.gameObject.GetComponent<Animator>().SetBool("Falando", true);
                spriteNPC.gameObject.GetComponent<Animator>().SetBool("Falando", false);
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

    IEnumerator TypeSentence(string sentenca)
    {
        foreach(char letter in sentenca.ToCharArray())
        {
            falaNPC.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
