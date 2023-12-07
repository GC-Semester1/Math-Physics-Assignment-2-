using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSquare : MonoBehaviour
{
    public float speed = 1.0f;


    void Update()
    {
        float xDir = 0.0f;
        float yDir = 0.0f;

        if (Input.GetKey(KeyCode.W))
        {
            yDir = 1.0f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            yDir = -1.0f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            xDir = -1.0f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            xDir = 1.0f;
        }



        Vector2 moveDirection = new Vector2(xDir, yDir).normalized;



        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}