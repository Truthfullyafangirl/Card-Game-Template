using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    //public List<Card> deck = new List<Card>();
    public List<Card> player_deck = new List<Card>();
    public List<Card> ai_deck = new List<Card>();
    public List<Card> player_hand = new List<Card>();
    public List<Card> ai_hand = new List<Card>();
    public List<Card> discard_pile = new List<Card>();
    public float card_size;
    public Transform _cavas;
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
            
        Deal();
       
        // SelectAndMoveRandomElement();
        // The code gave an error
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Deal()
    {
        float xOffset = 0;
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
            deltCard.transform.SetParent(_cavas);

        }
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
