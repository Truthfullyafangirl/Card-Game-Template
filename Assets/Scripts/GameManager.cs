using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public List<Card> deck = new List<Card>();
    public List<Card> player_deck = new List<Card>();
    public List<Card> ai_deck = new List<Card>();
    public List<Card> player_hand = new List<Card>();
    public List<Card> ai_hand = new List<Card>();
    public List<Card> discard_pile = new List<Card>();
    
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
        SelectAndMoveRandomElement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Deal()
    {
    }

    
    void Shuffle()
    {

    }

    void AI_Turn()
    {
        for (int i = 0; i < 3; i++)
        {
            int rand = Random.Range(0, ai_deck.Count);
            ai_hand[i] = ai_deck[rand];
            ai_deck.RemoveAt(rand);
        }
    }


    
    private void SelectAndMoveRandomElement()
    {
        for (int i = 0; i < 3; i++)
        {
            int rand = Random.Range(0, player_deck.Count);
            player_hand[i] = player_deck[rand];
            player_deck.RemoveAt(rand);
        }
    }
    

    
}
