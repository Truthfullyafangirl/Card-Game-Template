using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour , IPointerClickHandler 
{
    public static GameManager gm;
    //public List<Card> deck = new List<Card>();
    public List<Card> player_deck = new List<Card>();
    public List<Card> ai_deck = new List<Card>();
    public List<Card> player_hand = new List<Card>();
    public List<Card> ai_hand = new List<Card>();
    public List<Card> discard_pile = new List<Card>();
    public List<Card> ai_chosen = new List<Card>();
    public float card_size;
    public Transform _cavas;
    
    public int health; 
    public CardHud hud; 
    
    private void Awake()
    {
        if (gm != null && gm != this)
        {
            Destroy(gameObject);
        }
        else
        {
            gm = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Start is called before the first frame update
    
    void Start()
    {
        card_size = 200;
        health = 10; 
        Debug.Log(health);
        Deal();
       
        // SelectAndMoveRandomElement();
        // The code gave an error
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject())
        {
            print("clicked");


            PointerEventData pointer = new PointerEventData(EventSystem.current);
            pointer.position = Input.mousePosition;

            List<RaycastResult> raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointer, raycastResults);

            if (raycastResults.Count > 0)
            {
                foreach (var go in raycastResults)
                {
                    if (go.gameObject.transform.parent.name == "Heart card")
                    {
                        health += 1;
                        print(health);
                    } 

                    Debug.Log(go.gameObject.transform.parent.name);
                }
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked");
    }

    void Deal()
    {
        float xOffset = 0;
        for (int i = 0; i < 3; i++)
        {
            int rand = Random.Range(0, ai_deck.Count);
            ai_hand[i] = ai_deck[rand];
            ai_deck.RemoveAt(rand);
            int secrand = Random.Range(0, ai_hand.Count);
            ai_chosen[i] = ai_hand[secrand];
            ai_hand.RemoveAt(secrand);
        }
        
        for (int i = 0; i < 3; i++)
        {
            int playerrand = Random.Range(0, player_deck.Count);
            player_hand[i] = player_deck[playerrand];
            player_deck.RemoveAt(playerrand);
            Card deltCard =  Instantiate(player_hand[i], new Vector3(transform.position.x + xOffset, transform.position.y, 0),
                Quaternion.identity);
            
            //move the next card over
            xOffset += card_size;
            //child to canvas
            deltCard.transform.SetParent(_cavas);
        }
    }

    void PlayCard(Card card)
    {
        health += card.data.health;
    }


    void Shuffle()
    {

    }

    void AI_Turn()
    {
        
    }

    /*
    private void SelectAndMoveRandomElement()
    {
        for (int i = 0; i < 3; i++)
        {
            int rand = Random.Range(0, player_deck.Count);
            player_hand[i] = player_deck[rand];
            player_deck.RemoveAt(rand);
        }
    }
     // The code gave an error
    */
    
    
    
}
