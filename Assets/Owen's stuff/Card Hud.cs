using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardHud : MonoBehaviour
{
    

    public static CardHud hud;
    public int coins;
    public int health;
    public TextMeshProUGUI HealthText;
   
    
    // Start is called before the first frame update

    private void Awake()
    {
        if (hud !=null && hud!=this)
        {
            Destroy(gameObject);
        }
        else
        {
            hud = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    


    void Start()
    {
        health = 10;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        HealthText.text = "Health " + health; 
    }
}

