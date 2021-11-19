using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public UnityEvent trigger;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        trigger?.Invoke();
    }
}
