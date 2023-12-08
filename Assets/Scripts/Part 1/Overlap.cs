using Unity.Burst.Intrinsics;
using UnityEngine;

public class Overlap : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;

    //Overlap status storage
    private bool isOverlappingV1;
    private bool isOverlappingV2;
    private bool isOverlappingV3;

    
    void Update()
    {
        // Updates the overlap status of the objects
        UpdateOverlapStatus();

        // Sets the colors of the objects based on the overlap status
        SetObjectColors();
    }

    // Updates the overlap status for each pair of objects
    private void UpdateOverlapStatus()
    {
        //isOverlappingV1 Checks if object1 and object2 are overlapping
        //isOverlappingV2 Checks if object1 and object3 are overlapping
        //isOverlappingV3 Checks if object2 and object3 are overlapping
        
        isOverlappingV1 = CheckOverlap(object1, object2);

        isOverlappingV2 = CheckOverlap(object1, object3);

        isOverlappingV3 = CheckOverlap(object2, object3);
    }

    // Checks if 2 of the 3 primitives are overlapping
    private bool CheckOverlap(GameObject obj1, GameObject obj2)
    {
        // Get the bounds of the sprites or colliders of the 2 objects
        return GetBounds(obj1).Intersects(GetBounds(obj2));
    }

    // Get the bounds of the sprite or collider of a game object
    private Bounds GetBounds(GameObject obj)
    {
        // Try to get the SpriteRenderer component
        SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();

        // If a SpriteRenderer exists, return its bounds
        if (spriteRenderer != null)
        {
            return spriteRenderer.bounds;
        }

        // If a SpriteRenderer does not exist, try to get the Collider2D component
        Collider2D collider = obj.GetComponent<Collider2D>();
        if (collider != null)
        {
            // If a Collider2D is present, return its bounds
            return collider.bounds;
        }

        // If both do not exists, return as zero
        return new Bounds(Vector3.zero, Vector3.zero);
    }

    // Set the color of each game object based on the overlap status
    private void SetObjectColors()
    {
        // the color of object1 changes to green when it overlaps with object2 or object3
        // the color of object2 changes to green when it overlaps with object1 or object3
        // the color of object3 changes to green when it overlaps with object1 or object2

        SetObjectColor(object1, isOverlappingV1 || isOverlappingV2);

        SetObjectColor(object2, isOverlappingV1 || isOverlappingV3);

        SetObjectColor(object3, isOverlappingV2 || isOverlappingV3);
    }

    // Sets the color of a primitive based on the overlap status
    
    private void SetObjectColor(GameObject obj, bool isOverlapping)
    {
        // Sets the color of the SpriteRenderer component of the object to green if it is overlapping, or red if it is not overlapping
        // to green if it's overlapping, or red if it's not overlapping
        
        obj.GetComponent<SpriteRenderer>().color = isOverlapping ? Color.green : Color.red;
    }
}
