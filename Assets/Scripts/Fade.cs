using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class Fade : MonoBehaviour
{
    [SerializeField] Transicao transi;
    public UnityEvent OnFade;
    public CinemachineVirtualCamera camAtual;
    public CinemachineVirtualCamera camProx;
    public bool fading;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (transi.podeAction && fading == true)
        {
            OnFade?.Invoke();
            Cameras();
            fading = false;
            transi.podeAction = false;
            Interagir.podeAndar = true;
        }
        
    }

    public void IniciarFade()
    {
        transi.transicao = true;
        Interagir.podeAndar = false;
        fading = true;
    }

    public void Cameras()
    {
        camAtual.Priority = 0;
        camProx.Priority = 1;
    }

}
