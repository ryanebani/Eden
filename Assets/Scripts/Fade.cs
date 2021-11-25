using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class Fade : MonoBehaviour
{
    [SerializeField] Transicao transicao;
    [SerializeField] CinemachineVirtualCamera camAtual;
    [SerializeField] CinemachineVirtualCamera camProx;
    AudioSource audioSource;
    public UnityEvent OnFade;
    public bool TP;
    [SerializeField] GameObject[] desligar;
    [SerializeField] GameObject[] ligar;
    bool esteObj;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (transicao.podeAction && esteObj == true)
        {
            OnFade?.Invoke();
            Cameras();
            if (TP)
            {
                foreach (var item in desligar)
                {
                    item.SetActive(false);
                }

                foreach (var item in ligar)
                {
                    item.SetActive(true);
                }

            }
            Interagir.podeAndar = true;
            DialogoController.podeClickar = true;
            esteObj = false;
            transicao.podeAction = false;
            DialogoController.podeClickar = true;
        }
        
    }

    public void IniciarFade()
    {
        transicao.transicao = true;
        esteObj = true;
        Interagir.podeAndar = false;
        DialogoController.podeClickar = false;
        
    }

    public void Cameras()
    {
        if(camAtual != null && camProx != null)
        {
            camAtual.Priority = 0;
            camProx.Priority = 1;            
        }
       
    }

    public void InvertCameras()
    {
        if (camAtual != null && camProx != null)
        {
            camAtual.Priority = 1;
            camProx.Priority = 0;
        }

    }
    public void Som(AudioClip audioClip)
    {
        transicao.Som(audioClip);
    }

}
