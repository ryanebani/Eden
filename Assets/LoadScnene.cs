using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScnene : MonoBehaviour
{   
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ChamarMenu()
    {
        LoadScene("Menu");
        Botoes.irParaCreditos = true;
    }
}
