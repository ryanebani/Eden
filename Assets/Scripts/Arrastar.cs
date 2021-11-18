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

    public UnityEvent DragEnd;
    public bool dragging;

    RectTransform rectTrans;
    CanvasGroup canvasGroup;
      


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

}

  




