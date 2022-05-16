using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creditos : MonoBehaviour
{
    [SerializeField] float velocidade;
    Transform transformObjeto;

    void Start()
    {
        transformObjeto = GetComponent<Transform>();
    }

    void Update()
    {
        transformObjeto.Translate(Vector3.up * velocidade * Time.deltaTime);
    }
  
}
