using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Snap : MonoBehaviour
{
    [SerializeField] string tagCompare;
    [SerializeField] float snapX;
    [SerializeField] float snapY;


    bool canSnap = false;
    RectTransform myRectT;
    public UnityEvent OnTrigger;
    public UnityEvent OnGanhar;

    void Start()
    {
        myRectT = GetComponent<RectTransform>();        
    }


    void Update()
    {
 
    }

    public void onCanSnap(bool Ligar)
    {
        if (Ligar) canSnap = true;
        else canSnap = false;
        
    }

    void OnTriggerEnter2D(Collider2D colisor)
    {
        if (canSnap)
        {
            if (colisor.gameObject.tag == tagCompare)
            {
                OnTrigger?.Invoke();
                RectTransform colRectT = colisor.GetComponent<RectTransform>();
                myRectT.anchoredPosition = new Vector2(colRectT.anchoredPosition.x + snapX, colRectT.anchoredPosition.y + snapY);
                Debug.Log("Snap!");
            } 
            else if (colisor.gameObject.tag == "Correto" && gameObject.tag == "Correto")
            {
                OnGanhar?.Invoke();
            }
        }
    }

    public void Check()
    {

    }
}
