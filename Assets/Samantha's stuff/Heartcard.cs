using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heartcard : MonoBehaviour
{
    public bool heal;
    //public Damages damagesScript;
    //public int currentHealth; 
        
    // Start is called before the first frame update
    void Start()
    {
        heal = false;
        //damagesScript = GetComponent<Damages>(); 
        //int currentHealth = damagesScript.health;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

   public void OnMouseDown()
    {
        Debug.Log("Success"); 
        heal = true; 
    }

   public void EndOfTurn()
   {
       heal = false; 
   }
   
   
}
