using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Botoes : MonoBehaviour
{
    public GameObject creditos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jogar()
    {
        SceneManager.LoadScene("J1", LoadSceneMode.Single);
    }

    public void Creditos()
    {
        creditos.SetActive(true);
    }

    public void Voltar()
    {
        creditos.SetActive(false);
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
