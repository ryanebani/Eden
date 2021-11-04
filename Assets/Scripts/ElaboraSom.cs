using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class ElaboraSom : SorteiaSom

{
    public UnityEvent Sonoridade;

    [SerializeField] private float min;
    [SerializeField] private float max;

    [SerializeField] private float velocidade;

    [SerializeField] private Vector3 coordenada;

    private Transform objeto;

    private bool mover = false;
    private bool carro = false;

    private void Awake()
    {
       // Sonoridade.AddListener(ChamarSom);
       // Sonoridade?.Invoke();
    }

    private void ChamarSom()
    {
        EscolherSom();
        EsperarSom();
    }

    void Update()
    {
        if (mover)
        {
            objeto.position = new Vector3(objeto.position.x + velocidade, objeto.position.y, objeto.position.z);
        }
    }

    IEnumerator EsperarSom()
    {
        yield return new WaitForSeconds(Random.Range(min, max));
        Sonoridade?.Invoke();
    }


    private void MoverSom()
    {
        AleatorizarCoord();
        objeto = GetComponent<Transform>();

        if (coordenada.x <= 0)
        {
            velocidade *= 1;
        }
        else
        {
            velocidade *= -1;
        }

        objeto.position = coordenada;

        mover = true;
    }

    private void AleatorizarCoord()
    {
        coordenada.x = (Random.Range(-25, 25));

        /*if (clipes == Um som de carro)
        {
            carro = true;
        }
        */
        
        if (carro)
        {
            coordenada.y = -5;
        }
        else
        {
            coordenada.y = 10;
        }
    } 
}
