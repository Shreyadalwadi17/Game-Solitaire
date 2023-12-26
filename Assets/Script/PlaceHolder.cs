using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHolder : MonoBehaviour
{
    public List<RectTransform> placeHolder;
    private float offset = 0;
    public SpawnDeck spawnDeck;
    private int _index = 0;
    public Vector3 target;
    public float speed=2f;
   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaceCard();
            Block.OnCardSpawn?.Invoke();
           
        }
        
    }

    void PlaceCard()
    {
        for(int i=0; i<placeHolder.Count;i++)
        {
         
            for (int j=0; j<i+1; j++)
            { 
                //spawnDeck.deckGameObject[_index].GetComponent<CardPrefeb>().bcakFace.SetActive(false);
                spawnDeck.deckGameObject[_index].transform.position = new Vector3(placeHolder[i].transform.position.x, placeHolder[i].transform.position.y - offset, placeHolder[i].transform.position.z-offset);
                spawnDeck.deckGameObject[_index].transform.SetParent(placeHolder[i].transform);

                _index++;
               offset += 0.5f;
            }
           offset = 0;
        }
    }

   
  
    
}
