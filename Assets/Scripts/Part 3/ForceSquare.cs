using UnityEngine;

public class ForceSquare : MonoBehaviour
{
    public float mass = 10f;
    public float gravity = -9.8f;
    public float stopPosition = -0.95f;
    public float impulseForce = 1500f;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        // Checks for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Checks if the mouse click is within a certain range of the primitive's position 
            Vector3 mousePosition = Input.mousePosition;
            Vector3 objectPosition = Camera.main.WorldToScreenPoint(transform.position);
                                                   //The other two values represent the width and height of the primitive
            Rect objectRect = new Rect(objectPosition.x - 35f, objectPosition.y - 35f, 50f, 50f);

            //Checks to see if mouse was clicked  in a close enough range of a primitive to apply the 
            //impulse force to that specific one
            if (objectRect.Contains(mousePosition))
            {
                // Applies an impulse force upwards
                velocity += Vector3.up * impulseForce / mass;
            }
        }

        // Applies gravity
        Vector3 gravityForce = new Vector3(0f, gravity * mass, 0f);
        velocity += gravityForce * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        // Checks for stopPosition
        if (transform.position.y <= stopPosition)
        {
            velocity = Vector3.zero;
            transform.position = new Vector2(transform.position.x, stopPosition);
        }
    }
}
