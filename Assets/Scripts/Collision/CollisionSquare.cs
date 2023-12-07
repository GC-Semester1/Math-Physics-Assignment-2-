using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSquare : MonoBehaviour
{

    private Color defaultColor;


    void Start()
    {
        AddBoxCollider();

        defaultColor = GetComponent<SpriteRenderer>().color;
    }

    void AddBoxCollider()
    {
        BoxCollider2D boxCollider = gameObject.AddComponent<BoxCollider2D>();
        boxCollider.size = new Vector2(1.0f, 1.0f);
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