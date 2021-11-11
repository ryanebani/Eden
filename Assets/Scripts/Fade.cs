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
    public UnityEvent OnFade;   
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
            Interagir.podeAndar = true;
            DialogoController.podeClickar = true;
            esteObj = false;
            transicao.podeAction = false;
            
        }
        
    }

    public void IniciarFade()
    {
        transicao.transicao = true;
        esteObj = true;
        Interagir.podeAndar = false;
        
    }

    public void Cameras()
    {
        if(camAtual != null && camProx != null)
        {
            camAtual.Priority = 0;
            camProx.Priority = 1;
            
        }
       
    }

}
