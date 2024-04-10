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
    public float xOffset;
    private bool Delay;
    public bool startTimer = false;
    private float DelayTimer;
    public CardHud hud;
//<<<<<<< HEAD
    public bool playshieldcard; 
    
//=======
    public bool aiplayshieldcard; 
    
   
    public bool aicombat;
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
        Delay = false;
        DelayTimer = 1f;
        
        hud = GameObject.FindObjectOfType<CardHud>();
        card_size = 100;
        hud.health = 10;
        hud.aihealth = 10;
        Debug.Log(hud.health);
        Debug.Log(hud.aihealth);
        Deal(); 
       
        // SelectAndMoveRandomElement();
        // The code gave an error
        aicombat = true; 
        aiplayshieldcard = false; 
    }

    // Update is called once per frame
    void Update()
    {
        
        //health = hud.health;
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
                    
                    if (go.gameObject.transform.parent.name == "Heart card(Clone)" && go.gameObject.name == "Background")
                    {
                        hud.health += 1; 
                        AI_Turn();
                        print(hud.health);
                    }

                    if (go.gameObject.transform.parent.name == "Shield card(Clone)" && go.gameObject.name == "Background")
                    {
                        combat = false; 
                        AI_Turn();
                    }
                    
                    if (go.gameObject.transform.parent.name == "Sword card(Clone)" && go.gameObject.name == "Background")
                    {
                        
                        if (aiplayshieldcard == false)
                        {
                            hud.aihealth = hud.aihealth - 2; 
                            aicombat = true;
                            print(hud.aihealth);
                        }
                        
                        AI_Turn();
                        Debug.Log(hud.aihealth);
                        
                    }
                    
                    Debug.Log(go.gameObject.transform.parent.name);
                }
            }
        }

        if (startTimer)
        {
            DelayTimer -= Time.deltaTime;
            if (DelayTimer < 0)
            {
                Ending_turn();
                startTimer = false;
                DelayTimer = 1;
            }
        }
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked");
    }

    void Deal()
    {
        Delay = false;
        DelayTimer = 1f;
        
        
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
                Quaternion.identity, _canvas);
            
            //move the next card over
            xOffset += card_size;
            //child to canvas
            deltCard.transform.SetParent(_canvas); 
        }
    }

    void PlayCard()
    {
        
    }

    void Shuffle()
    {

    }

    void AI_Turn()
    {
        print("Aiturn");
        // Card deltCard =  Instantiate(ai_chosen, new Vector3(transform.position.x + xOffset , transform.position.y, 0),
        //Quaternion.identity);
        //deltCard.transform.SetParent(_cavas);

        int secrand = Random.Range(0, ai_hand.Count);
        ai_chosen = ai_hand[secrand];
        //start the timer, both cards have been selected
        startTimer = true;
        
        print(ai_chosen.name);
        
        ai_hand.RemoveAt(secrand);
        Card dealtCard = Instantiate(ai_chosen, new Vector3(transform.position.x + xOffset, transform.position.y, 0),
            Quaternion.identity);
        dealtCard.transform.SetParent(_canvas.transform);

        if (ai_chosen.name == ("Shield card"))
        {
            aiplayshieldcard = true;
            print(aiplayshieldcard);
        }

        if (ai_chosen.name == ("Sword card"))
        {
            if (combat = true)
            {
                hud.health = hud.health - 2;
            }
        }

        if (ai_chosen.name == ("Heart card"))
        {
            hud.aihealth = hud.aihealth + 1; 
        }
        
        if (aiplayshieldcard == true)
        {
            //if (aicombat == )
            {
                
            }
        }
        
    }

    void Ending_turn()
    {
        for (int i = player_hand.Count; i<0; i--)
        {
            player_deck.Add(player_hand[i]);
            player_hand.RemoveAt(i);
        }
        for (int i = ai_hand.Count; i<0; i--)
        {
            ai_deck.Add(ai_hand[i]);
            ai_hand.RemoveAt(i);
        }
        //mr ansell has no idea what goes here
        //ai_hand.RemoveAt();
    }
}

