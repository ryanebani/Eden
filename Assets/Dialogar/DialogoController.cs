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
        touch = Input.GetTouch(0);
        
        if (touch.phase == TouchPhase.Began && falaAtiva)
        {
            if (!falas.segmento)
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
                }
            }else
            {
                if(index < falas.sequencia.sequencia.Length)
                {
                    falaNPC.text = falas.sequencia.sequencia[index];
                    index++;
                }
                else
                {
                    index = 0;
                    if(!falas.sequencia.terminar)
                    {
                        ProximaFala(falas.sequencia.proximaFala);
                    }
                    else
                    {
                        falaAtiva = false;
                        painelDeDialogo.SetActive(false);
                        falaNPC.gameObject.SetActive(false);
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
        falas = fala;

        LimparRespostas();

        falaAtiva = true;
        painelDeDialogo.SetActive(true);
        falaNPC.gameObject.SetActive(true);

        falaNPC.text = falas.fala;
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
