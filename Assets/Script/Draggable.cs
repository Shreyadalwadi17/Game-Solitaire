using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class Draggable : CardPrefeb, IDragHandler, IPointerClickHandler, IEndDragHandler, IBeginDragHandler, IDropHandler
{
    //public CardSuit cardSuit;
    //public CardValue cardValue;
    public Vector3 position;
    public Vector3 startPosition;
    private float offset = 0.05f;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.LogWarning("DRAG");
        startPosition = transform.position;
        // tempp.inst.SortCard();
        transform.GetComponentInParent<Block>().canvas.sortingLayerName = "Selected";
        isHit = false;

    }

    public void OnDrag(PointerEventData drageventData)
    {

        GetComponent<CanvasGroup>().blocksRaycasts = false;
        position = Camera.main.ScreenToWorldPoint(new Vector3(drageventData.position.x, drageventData.position.y, 10f));
        transform.position = position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        transform.GetComponentInParent<Block>().canvas.sortingLayerName = "UnSelected";

        if (!isHit)
        {
            transform.position = startPosition;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("click point");
        GetComponent<CardPrefeb>().bcakFace.SetActive(false);
    }

    public void OnDrop(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        Debug.Log("dropped");

        if (eventData != null)
        {
            Debug.Log("not null");

            if ((int)eventData.pointerDrag.GetComponent<Draggable>().cardValue + 1 == (int)cardValue)
            {
                if ((int)eventData.pointerDrag.GetComponent<Draggable>().cardColor != (int)cardColor)
                {
                    Debug.Log("dropped value: " + cardColor);
                    Debug.Log("dragged value: " + eventData.pointerDrag.GetComponent<Draggable>().cardColor);

                    Debug.Log("dropped value: " + cardValue);
                    Debug.Log("dragged value: " + eventData.pointerDrag.GetComponent<Draggable>().cardValue);
                    Debug.Log("condition true");
                    eventData.pointerDrag.GetComponent<Draggable>().position = eventData.position;
                    eventData.pointerDrag.GetComponent<Draggable>().transform.SetParent(eventData.pointerEnter.transform);

                    Block.OnCardSpawn?.Invoke();
                    isHit = true;
                }
            }
          
            else if (eventData.pointerEnter.GetComponent<Block>())
            {
                isHit = true;
                
            }
        }

    }    
}
