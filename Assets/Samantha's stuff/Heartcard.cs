using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heartcard : MonoBehaviour
{
    
    public CardHud hud;
    public int health = 0;
        
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        health = hud.health;
        
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Mouse down");
        }
            
    }

   public void OnMouseDown()
    {
 //       Debug.Log("Success"); 
  //      EndOfTurn(); 
    } 

   public void EndOfTurn()
   {
       hud.health = hud.health + 1; 
   }
   
   
}
