using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewPlaceHolder : MonoBehaviour
{
    public SpawnDeck spawnDeck;
    public List<RectTransform> viewPlaceHolder;

    public int index = 28;

    public void Update()
    {
        
           
            DeckSort();
       
    }
    public void DeckSort()
    {
        if (Input.GetMouseButtonDown(1))
        {

            for (int i = 0; i < viewPlaceHolder.Count; i++)
            {
                spawnDeck.deckGameObject[index].transform.position = new Vector3(viewPlaceHolder[i].transform.position.x, viewPlaceHolder[i].transform.position.y, viewPlaceHolder[i].transform.position.z);
                spawnDeck.deckGameObject[index].transform.SetParent(viewPlaceHolder[i].transform);
                spawnDeck.deckGameObject[index].transform.GetComponent<CardPrefeb>().bcakFace.SetActive(false);
                index++;

            }
        }

    }


}

   

