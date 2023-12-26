using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDeck : MonoBehaviour
{
    public List<Card> deck;
    public CardPrefeb cardPrefab;
    public List<Sprite> suitType;
    public GameObject spawner;
    public List<GameObject> deckGameObject;
    public CardPrefeb cardd;
    public List<RectTransform> viewPlaceHolder;
    public List<Color> cardColor;
    

   
    void Start()
    {
       
        GenerateDeck();
        //ShuffleDeck();
    }

    void AddColor(Card card)
    {
        if (card.suit == CardSuit.Hearts || card.suit == CardSuit.Diamonds)
        {
            card.color = CardColor.Red;
        }
        else if (card.suit == CardSuit.Spades || card.suit == CardSuit.Clubs)
        {
            card.color = CardColor.Black;
        }
        
    }

    void GenerateDeck()
    {
        deck = new List<Card>();

        for (int suit = 0; suit <= (int)CardSuit.Spades; suit++)
        {
            for (int rank = 1; rank <= (int)CardValue.K; rank++)
            {
                for (int color = 0; color <= (int)CardColor.Red; color++)
                {
                    Card newCard = new Card((CardSuit)suit, (CardValue)rank, (CardColor)color);
                    AddColor(newCard);
                    deck.Add(newCard);
                }
            }
        }

        //ShuffleDeck();
        GenerateCardGameObject();
    }



    //public  void ShuffleDeck()
    //{
    //    for (int i = deck.Count - 1; i > 0; i--)
    //    {
    //        int randomIndex = Random.Range(0, i + 1);
    //        Card tempCard = deck[i];
    //        deck[i] = deck[randomIndex];
    //        deck[randomIndex] = tempCard;
    //    }
    //}

    public void GenerateCardGameObject()
    {
        deckGameObject = new();
        for (int i = 0; i < deck.Count; i++)
        {
            cardd = Instantiate(cardPrefab, this.transform);
            cardd.transform.localPosition = Vector3.zero;
            cardd.bcakFace.SetActive(true);
          
            deckGameObject.Add(cardd.gameObject);
            //ShuffleDeck();
           // Debug.Log("shuffle");
            if ((int)deck[i].value > 10 || (int)deck[i].value == 1)
            {
      
                cardd.upertext.text = deck[i].value + "";
                cardd.lowertext.text = deck[i].value + "";
                cardd.spriterender.sprite = suitType[(int)deck[i].suit];                
            }
            else
            {
                cardd.upertext.text = (int)deck[i].value + "";
                cardd.lowertext.text = (int)deck[i].value + "";
                cardd.spriterender.sprite = suitType[(int)deck[i].suit];
            }
        }
        GenerateDataInCard();
    }

    public void GenerateDataInCard()
    {
        for(int i=0;i< deck.Count; i++)
        {
            deckGameObject[i].GetComponent<CardPrefeb>().cardValue = deck[i].value;
            deckGameObject[i].GetComponent<CardPrefeb>().cardSuit = deck[i].suit;
            deckGameObject[i].GetComponent<CardPrefeb>().cardColor = deck[i].color;
            //deckGameObject[i].GetComponent<CardPrefeb>().cardValue = deck[i].value;
            //deckGameObject[i].GetComponent<CardPrefeb>().cardSuit = deck[i].suit;
            //deckGameObject[i].GetComponent<Draggable>().cardValue = deck[i].value;
            //deckGameObject[i].GetComponent<Draggable>().cardSuit = deck[i].suit;
            //deckGameObject[i].GetComponent<Droppable>().cardValue = deck[i].value;
            //deckGameObject[i].GetComponent<Droppable>().cardSuit = deck[i].suit;
        }
    }
  
}



public enum CardSuit
{
    Hearts,
    Diamonds,
    Clubs,
    Spades,
}


public enum CardValue
{
    A = 1,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    J,
    Q,
    K
}
public enum CardColor
{
    Black,
    Red
}

[System.Serializable]
public class Card
{
    public CardSuit suit;
    public CardValue value;
    public CardColor color;

    public Card(CardSuit suit, CardValue value,CardColor color)
    {
        this.suit = suit;
        this.value = value;
        this.color = color;
    }
  
}


