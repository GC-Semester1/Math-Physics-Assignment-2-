using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapColorChange : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private int width = 1;
    private int height = 1;

    private Color ifOverlapping = Color.green;
    private Color ifNotOverlapping = Color.red;

    void Start()
    {
        // Gets the SpriteRenderer 
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set the initial color to ifNotOverlapping (Red)
        AdjustColor(ifNotOverlapping);
    }

    void Update()
    {
        //Checks for overlap on each frame
        CheckForOverlap();
    }

    // Check for overlap between objects
    void CheckForOverlap()
    {
        // Collects all GameObjects with the tag "Primitive"
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Primitive");

        // Loops through each collected object
        for (int i = 0; i < allObjects.Length; i++)
        {
            GameObject currentPrimitive = allObjects[i];

            // Skips the current object in the loop
            if (currentPrimitive == gameObject)
                continue;

            // If an overlap is takes place, the color changes and is returned
            if (Overlap2D(gameObject, currentPrimitive))
            {
                WhenOverlapping(currentPrimitive);
                return;
            }
        }

        // If no overlap is taking place, the color is set to ifNotOverlapping (Red)
        AdjustColor(ifNotOverlapping);
    }

    // Sets the color of the SpriteRenderer
    void AdjustColor(Color color)
    {
        spriteRenderer.color = color;
    }

    // Adjusts spriteRenderer when an overlap takes place between two  of the primitives
    void WhenOverlapping(GameObject currentPrimitive)
    {
        AdjustColor(ifOverlapping);
    }

    // Checks for a 2D overlap between two of the primatives
    bool Overlap2D(float min1, float max1, float min2, float max2)
    {
        return (min2 <= max1 && max1 <= max2) || (min1 <= max2 && max2 <= max1);
    }

    // Check for a 2D overlap between two of the GameObjects (primatives)
    bool Overlap2D(GameObject object1, GameObject object2)
    {
        
        // Takes size and position into account
        
        Vector2 position1 = object1.transform.position;
        Vector2 position2 = object2.transform.position;

        float width1 = object1.transform.localScale.x;
        float width2 = object2.transform.localScale.x;

        float height1 = object1.transform.localScale.y;
        float height2 = object2.transform.localScale.y;

       
        // Calculates the minimum and maximum for each object
       
        float xMin1 = position1.x - width1 * 0.5f;
        float xMax1 = position1.x + width1 * 0.5f;

        float xMin2 = position2.x - width2 * 0.5f;
        float xMax2 = position2.x + width2 * 0.5f;

        float yMin1 = position1.y - height1 * 0.5f;
        float yMax1 = position1.y + height1 * 0.5f;

        float yMin2 = position2.y - height2 * 0.5f;
        float yMax2 = position2.y + height2 * 0.5f;

        // Checks for overlap in the X and Y axes for two of the primitives
        
        return Overlap2D(xMin1, xMax1, xMin2, xMax2) 
            && Overlap2D(yMin1, yMax1, yMin2, yMax2);
    }

    // Checks for a 2D overlap with the given  minimums and maximums of
    // two of the primitves in X and Y axes
    bool Overlap2D(
        float xMin1, float xMax1,
        float yMin1, float yMax1,
        float xMin2, float xMax2,
        float yMin2, float yMax2)
    {
        return Overlap2D(xMin1, xMax1, xMin2, xMax2) 
            && Overlap2D(yMin1, yMax1, yMin2, yMax2);
    }
}

