using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Damages : MonoBehaviour

{
    public static CardHud hud;
    public int health = 10; 

    public bool combat;
    // Start is called before the first frame update
    void Start()
    {
        combat = false;
    }

    // Update is called once per frame
    void Update()
    {

        //if(sheild card is clicked )
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
        if (health <=0 )
        {
            SceneManager.LoadScene("You lost");
        }

    }
        

    




    
    
    }


