using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCapsule : MonoBehaviour
{

    private Color defaultColor;


    void Start()
    {
        AddCapsuleCollider();

        defaultColor = GetComponent<SpriteRenderer>().color;
    }

    void AddCapsuleCollider()
    {
        CapsuleCollider2D capsuleCollider = gameObject.AddComponent<CapsuleCollider2D>();
        capsuleCollider.size = new Vector2(1.0f, 2.0f);
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
