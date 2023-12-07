using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCircle : MonoBehaviour
{
    public float speed = 1.0f;


    void Update()
    {
        float xDir = 0.0f;
        float yDir = 0.0f;

        if (Input.GetKey(KeyCode.I))
        {
            yDir = 1.0f;
        }
        else if (Input.GetKey(KeyCode.K))
        {
            yDir = -1.0f;
        }

        if (Input.GetKey(KeyCode.J))
        {
            xDir = -1.0f;
        }
        else if (Input.GetKey(KeyCode.L))
        {
            xDir = 1.0f;
        }



        Vector2 moveDirection = new Vector2(xDir, yDir).normalized;



        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}
