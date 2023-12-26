using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Block : MonoBehaviour
{
    public static Action OnCardSpawn;

    public Canvas canvas;

    public bool isEmpty;
   
    private void OnEnable()
    {
        OnCardSpawn += EnableFrontFaceCard;
    }

    private void OnDisable()
    {
        OnCardSpawn -= EnableFrontFaceCard;
    }

    public void EnableFrontFaceCard()
    {
        if (transform.childCount != 0)
        {
            isEmpty = false;
            Transform card = transform.GetChild(transform.childCount - 1);
            //Debug.Log(transform.childCount);
            //Debug.Log(card.name);
            card.GetComponent<CardPrefeb>().bcakFace.SetActive(false);
            card.GetComponent<CardPrefeb>().isMoveable = true;
            card.GetComponent<Draggable>().enabled = true;
            //card.GetComponent<Droppable>().enabled = true;

            //for (int i = 0; i < transform.childCount; i++)
            //{
            //    card.GetComponent<CardPrefeb>().SetIntialPosition(transform.GetChild(i).position);
            //}
        }
        else
        {
            isEmpty = true;
        }

    }
}





