using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCharacter : MonoBehaviour
{
    [SerializeField]
    private Transform alvo;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = alvo.position + new Vector3 (15.8f, 1.8f, 0);
    }
}
