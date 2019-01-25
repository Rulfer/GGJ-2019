using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side : MonoBehaviour
{
    HashSet<GameObject> elementsInside = new HashSet<GameObject>();
    public int enterCounter;
    public int leavecounter;
    GameObject side;

    void Start()
    {
        side = FindObjectOfType<Side>().gameObject;
        enterCounter = 0;
        leavecounter = 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Throwable") {
            enterCounter += 1;
            elementsInside.Add(collision.gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Throwable")
        {
            leavecounter += 1;
            elementsInside.Remove(collision.gameObject);
        }
    }
}
