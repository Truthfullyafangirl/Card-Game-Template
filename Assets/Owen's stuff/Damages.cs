using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Damages : MonoBehaviour

{
    public static CardHud hud;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
    
    
    
    }
}

