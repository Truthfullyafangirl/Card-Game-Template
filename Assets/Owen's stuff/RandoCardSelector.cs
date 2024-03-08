using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandoCardSelector : MonoBehaviour
{
    public List<GameObject> sourceList; // List of game objects to select from
    public List<GameObject> destinationList;// list it will move to
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectAndMoveRandomElement()
    {
        if (sourceList.Count == 0)
        {
            Debug.LogWarning("The source list of elements is empty!");
            return;
        }

        // Generate a random index within the range of the source list
        int randomIndex = Random.Range(0, sourceList.Count);

        // Get the randomly selected element from the source list
        GameObject selectedElement = sourceList[randomIndex];

        // Move the selected element to the destination list
        destinationList.Add(selectedElement);

        // Remove the selected element from the source list
        sourceList.RemoveAt(randomIndex);

        Debug.Log("Selected and moved element: " + selectedElement.name);
    }
}
