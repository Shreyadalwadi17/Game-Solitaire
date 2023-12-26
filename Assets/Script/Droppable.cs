using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Droppable : MonoBehaviour, IDropHandler
{
    //public CardSuit cardSuit;
    //public CardValue cardValue;
    public Vector3 position;

    public void OnDrop(PointerEventData eventData)
    {                
        Debug.Log("dropped");

        if (eventData != null)
        {
            Debug.Log("not null");

            if (eventData.pointerEnter.GetComponent<Block>())
            {

                eventData.pointerDrag.GetComponent<Draggable>().position = eventData.position;                
            }            
        }       
    }      
}
