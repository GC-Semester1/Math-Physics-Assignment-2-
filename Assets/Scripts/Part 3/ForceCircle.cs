using UnityEngine;

public class ForceCircle : MonoBehaviour
{
    public float mass = 15f;
    public float gravity = -9.8f;
    public float stopPosition = -0.95f;
    public float impulseForce = 500f;
    private Vector3 velocity = Vector3.zero;


    void Update()
    {
        // Determines if mouse is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Applys an impulse force upwards
            velocity += Vector3.up * impulseForce / mass;
        }

        // Applys gravity
        Vector3 gravityForce = new Vector2(0f, gravity * mass);
        velocity += gravityForce * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        if (transform.position.y <= stopPosition)
        {
            velocity = Vector3.zero;

            transform.position = new Vector2(transform.position.x, stopPosition);
        }
    }
}
