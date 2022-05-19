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
    public static bool irParaCreditos;
    bool inicio = true;
    Creditos creditosScript;

    // Start is called before the first frame update
    void Start()
    {
        creditosScript = FindObjectOfType<Creditos>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && inicio)
        {
            logo.Priority = 0;
            menu.Priority = 1;
            inicio = false;
        }
        if (Input.touchCount > 0 && inicio)
        {
            logo.Priority = 0;
            menu.Priority = 1;
            inicio = false;
        }

        if (irParaCreditos)
        {
            inicio = false;
            Creditos();
            creditosScript.SetCreditos();
            irParaCreditos = false;
        }
    }

    public void Jogar()
    {
        creditos.Priority = 0;
        menu.Priority = 0;
        logo.Priority = 1;
        SceneManager.LoadScene("J1", LoadSceneMode.Single);
    }

    public void Creditos()
    {
        logo.Priority = 0;
        menu.Priority = 0;
        creditos.Priority = 1;
    }

    public void Voltar()
    {
        logo.Priority = 0;
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
