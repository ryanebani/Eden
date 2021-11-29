using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoMute : MonoBehaviour
{
    public Sprite mutado;
    public Sprite desmutado;
    bool mudo;
    //AudioListener pontoDeEscuta;

    private void Start()
    {
        mudo = false;
        AudioListener.pause = false;
    }
    public void Mudar()
    {
        mudo = !mudo;
        if(mudo)
        {
            AudioListener.pause = true;
            GetComponent<Image>().sprite = mutado;
        }
        else
        {
            AudioListener.pause = false;
            GetComponent<Image>().sprite = desmutado;
        }
    }
}
