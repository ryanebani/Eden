using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ArrastarItem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] Canvas canvas;
    bool dragging;
    bool pontoCheck;
    Slots slots;

    RectTransform rectTrans;
    Vector3 posInicial;
    Vector2 ponto;

    // Start is called before the first frame update
    void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        posInicial = rectTrans.anchoredPosition;
        slots = GetComponent<Slots>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }
    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //dragging = true;
        posInicial = rectTrans.anchoredPosition;
        slots.SelecionarParaQuest();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTrans.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rectTrans.anchoredPosition = posInicial;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {         

                if (CanvasItens.CanvasAberto == false)
                {
                    ponto = Camera.main.ScreenToWorldPoint(touch.position);
                    RaycastHit2D hit = Physics2D.Raycast(ponto, -Vector2.up, 0.05f);

                    if (hit.collider.tag == "NPC" || hit.collider.tag == "ObjInt")
                    {
                        Interagir.paraOndeVou = hit.collider.name;
                        Interagir.itemSelecionado = slots.nome;
                        Interagir.itemNaMao = true;
                    }
                }
                else
                {
                    RaycastHit2D hit = Physics2D.Raycast(touch.position, -Vector2.up, 0.05f);
                    if(hit.collider.tag == "Finish")
                    {
                        Interagir.itemSelecionado = slots.nome;
                        Interagir.itemNaMao = true;
                        CanvasItens canvasItens;
                        canvasItens = hit.collider.gameObject.GetComponent<CanvasItens>();
                        canvasItens.EntregarItem();
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (CanvasItens.CanvasAberto == false)
            {
                ponto = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ponto, -Vector2.up, 0.05f);

                if (hit.collider.tag == "NPC" || hit.collider.tag == "ObjInt")
                {
                    Interagir.paraOndeVou = hit.collider.name;
                    Interagir.itemSelecionado = slots.nome;
                    Interagir.itemNaMao = true;
                }
            }
            else
            {
                RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, -Vector2.up, 0.05f);
                if (hit.collider.tag == "Finish")
                {
                    Interagir.itemSelecionado = slots.nome;
                    Interagir.itemNaMao = true;
                    CanvasItens canvasItens;
                    canvasItens = hit.collider.gameObject.GetComponent<CanvasItens>();
                    canvasItens.EntregarItem();
                }
            }
        }

        //DragEnd?.Invoke();
    }
}
