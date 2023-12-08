using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float mass = 10f;
    public float gravity = -9.8f;

    // This is meant to give the primitives an initial velocity of 0 and updates accordingly over time
    private Vector3 velocity = Vector3.zero;

    // The height at which the object should stop falling
    public float stopPosition = -3.5f;

    void Update()
    {
        // Calculates the gravitational force
        Vector3 gravityForce = new Vector3(0f, gravity * mass, 0f);

        // Updates the velocity using the gravitational force
        velocity += gravityForce * Time.deltaTime;

        // Updates the position based on the velocity
        transform.position += velocity * Time.deltaTime;

        // Checks if the primitives have reached the stopPosition
        if (transform.position.y <= stopPosition)
        {
            // Sets velocity to zero to stop the primitives from falling any longer
            velocity = Vector3.zero;

            // This is the position of the stopPosition
            transform.position = new Vector2(transform.position.x, stopPosition);
        }
    }
}
