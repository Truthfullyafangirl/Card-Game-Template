using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heartcard : MonoBehaviour
{
    public bool heal;  
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        heal = false; 
    }

   public void OnMouseDown()
    {
        Debug.Log("Success"); 
        heal = true; 
    }
}
