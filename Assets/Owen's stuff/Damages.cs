using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Damages : MonoBehaviour

{
    public static CardHud hud;
    public int health;

    public bool combat;
    // Start is called before the first frame update
    void Start()
    {
        combat = false;
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
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
            // Switch to the next scene
            SceneManager.LoadScene("Title screen");
        }

    }
        
=======
       // if (("combat"))
      //  {
      //      ChangeHealth(-1);
      //  } 
        
      //   if ("health")) 
      //  {
      //      ChangeHealth( +1);
      //      other.gameObject.SetActive(false);
        
      
    
      if (health <=0 )
      {
          // Switch to the next scene
          SceneManager.LoadScene("Title screen");
      }
>>>>>>> b66b8a022703537b5e4b7687557bef4db3552b6b
    




    
    
    }


