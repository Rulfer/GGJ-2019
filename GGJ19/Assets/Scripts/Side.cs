using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side : MonoBehaviour
{
    HashSet<GameObject> elementsInside = new HashSet<GameObject>();

    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Throwable")
            elementsInside.Add(collision.gameObject);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Throwable")
            elementsInside.Remove(collision.gameObject);
    }
}
