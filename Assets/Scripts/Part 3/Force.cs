using UnityEngine;

public class Force : MonoBehaviour
{
    public float mass = 10f;
    public float gravity = -9.8f;

    // This is meant to give the primitives an initial velocity of 0 and updates accordingly over time
    private Vector3 velocity = Vector3.zero;

    // The height at which the object should stop falling
    public float stopHeight = 5f;

    // Impulse force applied when clicking on the object
    public float impulseForce = 20f;

    void Update()
    {
        // Calculates the gravitational force
        Vector3 gravityForce = new Vector3(0f, gravity * mass, 0f);

        // Updates the velocity using the gravitational force
        velocity += gravityForce * Time.deltaTime;

        // Updates the position based on the velocity
        transform.position += velocity * Time.deltaTime;

        // Check if the object has reached the stopHeight
        if (transform.position.y <= stopHeight)
        {
            // Set velocity to zero to stop falling
            velocity = Vector3.zero;

            // Set the position to the stopHeight to ensure it stays on top
            transform.position = new Vector3(transform.position.x, stopHeight, transform.position.z);
        }

        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the mouse click is over the object
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                // Apply an impulse force upwards
                velocity += Vector3.up * impulseForce / mass;
            }
        }
    }
}
