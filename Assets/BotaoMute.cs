using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoMute : MonoBehaviour
{
    public Sprite mutado;
    public Sprite desmutado;
    bool mudo;
    AudioListener pontoDeEscuta;

    private void Start()
    {
        pontoDeEscuta = FindObjectOfType<AudioListener>();
    }
    public void Mudar()
    {
        mudo = !mudo;
        if(mudo)
        {
            pontoDeEscuta.enabled = false;
            GetComponent<Image>().sprite = mutado;
        }
        else
        {
            pontoDeEscuta.enabled = true;
            GetComponent<Image>().sprite = desmutado;
        }
    }
}
