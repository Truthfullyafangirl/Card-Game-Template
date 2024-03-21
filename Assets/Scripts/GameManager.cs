using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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
    public Card ai_chosen;
    public float card_size;
    public Transform _canvas;
    float xOffset = 0;
    
    public int health; 
    public CardHud hud;
    public int aihealth;
//<<<<<<< HEAD
    public bool playshieldcard; 
    public Canvas canvas;
//=======
    public bool aiplayshieldcard; 
    
   
    public bool combat;
    
    
//>>>>>>> 37cc9a88d4105d8a4b05d72736c31c63508519fe
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
        aihealth = 10;
        Debug.Log(health);
        Debug.Log(aihealth);
        Deal(); 
       
        // SelectAndMoveRandomElement();
        // The code gave an error
        combat = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        health = hud.health;
        
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
                    
                    print(go.gameObject.name);
                    
                    if (go.gameObject.transform.parent.name == "Heart card" && go.gameObject.name == "Background")
                    {
                        health += 1; 
                        print(health);
                    }

                    if (go.gameObject.transform.parent.name == "Shield card" && go.gameObject.name == "Background")
                    {
                        //aiplayshieldcard = true; (incorrect, this is in us playing the card)
                    }
                    
                    if (go.gameObject.transform.parent.name == "Sword card" && go.gameObject.name == "Background")
                    {
                        if (aiplayshieldcard == true)
                        {
                            
                        }
                        
                        else
                        {
                            aihealth = aihealth - 1;
                            print(aihealth);
                        }
                        
                        Debug.Log(aihealth);
                    }
                    
                    Debug.Log(go.gameObject.transform.parent.name);
                }
            }
        }
        //if(shield card is clicked )
        {
            combat = false;
        }
        //else if (sword card is clicked)
        {
            combat = true; 
        }
        //if (combat = true || end of turn )
        {
            //       health(-1);
        }
        //  if ("healthcard"))
        {
            //      health(+1);
        }
        //if (health <=0)
        {
            //SceneManager.LoadScene("You lost");
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked");
    }

    void Deal()
    {
       
        for (int i = 0; i < 3; i++)
        {
            int rand = Random.Range(0, ai_deck.Count);
            ai_hand[i] = ai_deck[rand];
            ai_deck.RemoveAt(rand);
            
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
            deltCard.transform.SetParent(_canvas); 
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
       // Card deltCard =  Instantiate(ai_chosen, new Vector3(transform.position.x + xOffset , transform.position.y, 0),
            //Quaternion.identity);
        //deltCard.transform.SetParent(_cavas);
        
        int secrand = Random.Range(0, ai_hand.Count);
        ai_chosen = ai_hand[secrand];
        ai_hand.RemoveAt(secrand);
        Card dealtCard = Instantiate(ai_chosen, new Vector3(transform.position.x + xOffset, transform.position.y, 0), Quaternion.identity);
        dealtCard.transform.SetParent(canvas.transform);
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
