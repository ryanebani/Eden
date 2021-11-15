using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralaxe : MonoBehaviour
{
    //private float tamanho;
    private float posInicial;
    //private float posRestart;

    private Transform cam;

    [SerializeField]
    private float efeitoParalaxe;

    float distancia;

    void Start()
    {
        posInicial = transform.position.x;
        //tamanho = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main.transform;
    }

    void Update()
    {
        //posRestart = cam.transform.position.x * (1 - efeitoParalaxe);

        distancia = cam.transform.position.x * efeitoParalaxe;

        transform.position = new Vector3(posInicial + distancia, transform.position.y, transform.position.z);

        /*if (posRestart > posInicial + tamanho)
        {
            posInicial += tamanho;
        }
        else if (posRestart < posInicial - tamanho)
        {
            posInicial -= tamanho;
        }
        */
    }
}
