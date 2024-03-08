using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heartcard : MonoBehaviour
{
    public var heal; 
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        heal = true; 
        Debug.Log("Success"); 
    }
}
