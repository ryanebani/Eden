using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class Botoes : MonoBehaviour
{
    public CinemachineVirtualCamera logo;
    public CinemachineVirtualCamera menu;
    public CinemachineVirtualCamera creditos;
    bool inicio = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && inicio)
        {
            logo.Priority = 0;
            menu.Priority = 1;
            inicio = false;
        }
    }

    public void Jogar()
    {
        menu.Priority = 0;
        logo.Priority = 1;
        SceneManager.LoadScene("J1", LoadSceneMode.Single);
    }

    public void Creditos()
    {
        menu.Priority = 0;
        creditos.Priority = 1;
    }

    public void Voltar()
    {
        creditos.Priority = 0;
        menu.Priority = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void Cutscene()
    {
        SceneManager.LoadScene("Cutscene", LoadSceneMode.Single);
    }
}
