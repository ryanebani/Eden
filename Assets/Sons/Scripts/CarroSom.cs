using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroSom : MonoBehaviour
{
    //[SerializeField] AudioClip[] buzinas;
    [SerializeField] AudioClip[] carros;

    [SerializeField] private float min;
    [SerializeField] private float max;

    [SerializeField] private float velMin;
    [SerializeField] private float velMax;

    SpriteRenderer sprite;
    public float velocidade;
    AudioSource audioSource;
    Vector3 coordenadaD;
    Vector3 coordenadaE;

    private bool mover = false;

    void Start()
    {
        mover = false;
        sprite = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        coordenadaD = new Vector3(100, transform.position.y, 0);
        coordenadaE = new Vector3(-100, transform.position.y, 0);
        StartCoroutine(Timer());
    }

    
    void Update()
    {
        if (mover)
        {
            transform.position = new Vector3(transform.position.x + velocidade, transform.position.y, transform.position.z * Time.deltaTime);
            if(transform.position.x > coordenadaD.x || transform.position.x < coordenadaE.x)
            {
                
                if(audioSource.isPlaying == false)
                {
                    mover = false;
                    StartCoroutine(Timer());
                }
                
            }
        }

    }
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(Random.Range(min, max));

        SetCoordenada();
        SetVelocidade();
        audioSource.Play();
        mover = true;
    }

    public void SetCoordenada()
    {
        int indice = Random.Range(0, 2);
        if (indice == 0)
        {
            transform.position = coordenadaD;
            sprite.flipX = true;
        }
        else
        {
            transform.position = coordenadaE;
            sprite.flipX = false;
        }

        //Debug.Log(indice);
    }

    private void SetVelocidade()
    {
        velocidade = Random.Range(velMin, velMax);

        if (transform.position == coordenadaE)
        {
            velocidade = velocidade * 1;
            
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            velocidade = velocidade * -1;
            
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
    }


}
