using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Snap : MonoBehaviour
{
    [SerializeField] bool correto;
    [SerializeField] string tagCompare;
    [SerializeField] float snapX;
    [SerializeField] float snapY;

    RectTransform myRectT;
    

    bool canSnap;

    public UnityEvent OnTrigger;
    public UnityEvent OnGanhar;

    void Start()
    {
        myRectT = GetComponent<RectTransform>();        
    }


    void Update()
    { 
    }

    public void OnCanSnap()
    {
        StartCoroutine(Timer());
    }
  
    void OnTriggerStay2D(Collider2D colisor)
    {

        if (colisor.gameObject.tag == tagCompare && canSnap)
        {
                
            RectTransform colRectT = colisor.GetComponent<RectTransform>();
            myRectT.anchoredPosition = new Vector2(colRectT.anchoredPosition.x + snapX, colRectT.anchoredPosition.y + snapY);
            OnTrigger?.Invoke();

            if (colisor.gameObject.GetComponent<Snap>().correto)
            {
                OnGanhar?.Invoke();
                Debug.Log("ganhou");
                
            }            
        }

    }

    IEnumerator Timer()
    {
        canSnap = true;
        yield return new WaitForSeconds(0.1f);
        canSnap = false;
    }
}
