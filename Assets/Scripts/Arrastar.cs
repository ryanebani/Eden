using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Arrastar : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject panel;
    [SerializeField] Image panelChild;
    [SerializeField] Sprite zoom;
    [SerializeField] Arrastar controller;

    public UnityEvent DragEnd;
    public UnityEvent Contador;
    public bool dragging;

    RectTransform rectTrans;
    CanvasGroup canvasGroup;
    public int contador;
    public int marca;

    public void Update()
    {
        if(contador >= marca)
        {
            Contador?.Invoke();
        }
    }

    void Awake()
    {
        rectTrans = GetComponent<RectTransform>(); 
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        //Zoom();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragging = true;
        //Sibbling();
    }

    public void OnDrag(PointerEventData eventData)
    {
       rectTrans.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       dragging = false;
       DragEnd?.Invoke();
    }

    public void Zoom()
    {
        if (dragging == false && panel!)
        {
            panelChild.sprite = zoom;            
            panelChild.SetNativeSize();
            panel.SetActive(true);
        }
    }

    public void Sibbling()
    {
        gameObject.transform.SetAsLastSibling();
    }

    public void Coletar()
    {
        gameObject.SetActive(false);
        controller.contador ++;
    }

}

  




