using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogoController : MonoBehaviour
{
    public GameObject painelDeDialogo;

    public Text falaNPC;

    public GameObject resposta;

    private bool falaAtiva = false;

    FalaNPC falas;

    Touch touch;

    int index = 0;


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
                        painelDeDialogo.SetActive(false);
                        falaNPC.gameObject.SetActive(false);
                        Interagir.podeAndar = true;
                    }
                }
                else
                {
                    if (index < falas.sequencia.sequencia.Length)
                    {
                        falaNPC.text = falas.sequencia.sequencia[index];
                        if (falas.sequencia.npcFalando[index])
                        {
                            falaNPC.color = falas.corNPC;
                        }
                        else
                        {
                            falaNPC.color = falas.corPlayer;
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
                        }

                    }

                }
            }
        }
    }

    void MostarRespostas()
    {
        falaNPC.gameObject.SetActive(false);
        falaAtiva = false;

        for(int i = 0; i < falas.respostas.Length; i++)
        {
            GameObject tempResposta = Instantiate(resposta, painelDeDialogo.transform) as GameObject;
            tempResposta.GetComponent<Text>().text = falas.respostas[i].resposta;
            tempResposta.GetComponent<AnswerButton>().Setup(falas.respostas[i]);
        }
    }

    public void ProximaFala(FalaNPC fala)
    {
        Interagir.podeAndar = false;
        falas = fala;

        LimparRespostas();

        falaAtiva = true;
        painelDeDialogo.SetActive(true);
        falaNPC.gameObject.SetActive(true);

        falaNPC.text = falas.fala;
        if(falas.npcFalando)
        {
            falaNPC.color = falas.corNPC;
        }
        else
        {
            falaNPC.color = falas.corPlayer;
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
