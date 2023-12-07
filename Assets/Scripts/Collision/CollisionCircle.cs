using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCircle : MonoBehaviour
{

    private Color defaultColor;


    void Start()
    {
        AddCircleCollider();

        defaultColor = GetComponent<SpriteRenderer>().color;

    }


    void AddCircleCollider()
    {
        CircleCollider2D circleCollider = gameObject.AddComponent<CircleCollider2D>();
        circleCollider.radius = 0.5f;
    }


    void OnCollisionEnter2D(Collision2D collision)

    {
        if (collision.gameObject.CompareTag("Primitive"))
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }


    }

    void OnCollisionExit2D(Collision2D collision)

    {
        if (collision.gameObject.CompareTag("Primitive"))
        {
            GetComponent<SpriteRenderer>().color = defaultColor;
        }


    }


    void Update()
    {

    }
}

