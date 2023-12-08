using UnityEngine;

public class ForceCircle : MonoBehaviour
{
    public float mass = 15f;
    public float gravity = -9.8f;
    public float stopPosition = -0.95f;
    public float impulseForce = 3000f;
    private Vector3 velocity = Vector3.zero;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 objectPosition = Camera.main.WorldToScreenPoint(transform.position);
           
            Rect objectRect = new Rect(objectPosition.x - 35f, objectPosition.y - 35f, 50f, 50f);

            if (objectRect.Contains(mousePosition))
            {
                velocity += Vector3.up * impulseForce / mass;
            }
        }

        Vector3 gravityForce = new Vector3(0f, gravity * mass, 0f);
        velocity += gravityForce * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        if (transform.position.y <= stopPosition)
        {
            velocity = Vector3.zero;
            transform.position = new Vector2(transform.position.x, stopPosition);
        }
    }
}
