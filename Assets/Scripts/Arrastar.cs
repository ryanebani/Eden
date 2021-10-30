using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Arrastar : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject imageZoom;
    

    public UnityEvent OnUp;
    public UnityEvent OnDown;
    public UnityEvent OnBDrag;
    public UnityEvent OnDragging;
    public UnityEvent OnEDrag;

    public bool dragging;
    [SerializeField]bool canDrag;

    RectTransform rectTrans;
    CanvasGroup canvasGroup;
      


    void Awake()
    {
        rectTrans = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();      
    }
    
    void Update()
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnUp?.Invoke();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        OnDown?.Invoke();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        OnBDrag?.Invoke();
        dragging = true;
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnDragging?.Invoke();

        if (canDrag)
        {
            rectTrans.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
       
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        OnEDrag?.Invoke();
        StartCoroutine(dragCheck());
    }

    public void Zoom()
    {
        if (dragging == false && imageZoom!)
        {
            imageZoom.SetActive(true);
        }
    }

    public void Sibbling()
    {
        gameObject.transform.SetAsLastSibling();
    }


    IEnumerator dragCheck()
    {
        yield return new WaitForSeconds(0.1f);
        dragging = false;
    }


    public void DragCancel(bool ligar)
    {
        if (ligar)
            canDrag = false;
        else canDrag = true;
    }
}

  




