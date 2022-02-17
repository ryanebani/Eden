using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Cano : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] somCanos;

    private AudioSource canoSource;


    public string forma;

    public string direcaoFinal;

    [HideInInspector]
    public bool cima, baixo, esq, dir;
    private bool espCima, espBaixo, espEsq, espDir;

    [HideInInspector]
    public bool ativo;
    [HideInInspector]
    public bool permAtivo;

    public bool trancado;

    private Canos canos;

    private Image image;

    public UnityEvent OnFinalGame;

    public int rand;
    private void Start()
    {
        image = GetComponent<Image>();
        canos = GetComponentInParent<Canos>();
        canoSource = GetComponent<AudioSource>();

        if (forma == "I")
        {
            image.sprite = canos.sprites[0];
            if(rand == 0)
            {
                esq = true;
                dir = true;
                
            }
            else if(rand == 1)
            {
                image.gameObject.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, -90));
                cima = true;
                baixo = true;
            }
        }
        else if(forma == "L")
        {
            image.sprite = canos.sprites[1];
            if(rand == 0)
            {
                esq = true;
                baixo = true;
            }
            else if(rand == 1)
            {
                image.gameObject.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, -90));
                cima = true;
                esq = true;
            }
            else if(rand == 2)
            {
                image.gameObject.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, -180));
                cima = true;
                dir = true;
            }
            else if(rand == 3)
            {
                image.gameObject.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, -270));
                dir = true;
                baixo = true;
            }
        }
        else if(forma == "T")
        {
            image.sprite = canos.sprites[2];
            if (rand == 0)
            {
                cima = true;
                dir = true;
                baixo = true;
            }
            else if (rand == 1)
            {
                image.gameObject.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, -90));
                dir = true;
                baixo = true;
                esq = true;
            }
            else if (rand == 2)
            {
                image.gameObject.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, -180));
                baixo = true;
                esq = true;
                cima = true;
            }
            else if (rand == 3)
            {
                image.gameObject.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, -270));
                esq = true;
                cima = true;
                dir = true;
            }
        }
        else if(forma == "+")
        {
            image.sprite = canos.sprites[3];
            cima = true;
            dir = true;
            baixo = true;
            esq = true;
        }
        else if(forma == "O")
        {
            image.sprite = canos.sprites[4];
            cima = true;
            dir = true;
            baixo = true;
            esq = true;
            permAtivo = true;
            trancado = true;
        }
        else if(forma == "X")
        {
            image.sprite = canos.sprites[5];
            trancado = true;
            if(direcaoFinal == "direita")
            {
                dir = true;
            }
            else if (direcaoFinal == "baixo")
            {
                image.gameObject.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, -90));
                baixo = true;
            }
            else if (direcaoFinal == "esquerda")
            {
                image.gameObject.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, -180));
                esq = true;
            }
            else if (direcaoFinal == "cima")
            {
                image.gameObject.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, -270));
                cima = true;
            }
            else
            {
                dir = true;
            }
        }
        else
        {
            image.sprite = canos.sprites[6];
            trancado = true;
        }

        
    }

    private void Update()
    {
        /*
        if (trancado && ativo || permAtivo)
        {
            image.color = Color.green;
        }
        else if (trancado)
        {
            image.color = Color.red;
        }
        else if (ativo || permAtivo)
        {
            image.color = Color.cyan;
        }
        else
        {
            image.color = Color.white;
        }
        */
        if(forma == "X" && ativo)
        {
            OnFinalGame?.Invoke();
        }

    }

    public void Girar()
    {
        if(!trancado)
        {
            foreach(Cano c in canos.canos)
            {
                c.ativo = false;
            }
            image.gameObject.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, -90));
            SomAoGirar();
            if (cima)
            {
                cima = false;
                espDir = true;
            }
            if (esq)
            {
                esq = false;
                espCima = true;
            }
            if (baixo)
            {
                baixo = false;
                espEsq = true;
            }
            if (dir)
            {
                dir = false;
                espBaixo = true;
            }

            if (espCima)
            {
                espCima = false;
                cima = true;
            }
            if (espEsq)
            {
                espEsq = false;
                esq = true;
            }
            if (espBaixo)
            {
                espBaixo = false;
                baixo = true;
            }
            if (espDir)
            {
                espDir = false;
                dir = true;
            }
        }
        
    }

    private void SomAoGirar()
    {
        canoSource.clip = somCanos[Random.Range(0, somCanos.Length)];
        canoSource.Play();
    }
}
