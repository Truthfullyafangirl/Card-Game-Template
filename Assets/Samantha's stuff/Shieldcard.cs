using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shieldcard : MonoBehaviour
{
    public Damages combat;
    
    // Start is called before the first frame update
    void Start()
    {
        combat.combat = true; 
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    void OnMouseDown()
    { 
        //combat.combat = false; 
    }
}
