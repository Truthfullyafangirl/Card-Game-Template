using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Damages : MonoBehaviour

{
    public CardHud hud;
    public bool combat;

    public int health = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        combat = false;
    }

    // Update is called once per frame
    void Update()
    {
        health = hud.health;
        
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
        

    




    
    
    }


