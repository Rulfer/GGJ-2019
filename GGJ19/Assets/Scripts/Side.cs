using System.Collections.Generic;
using UnityEngine;

public class Side : MonoBehaviour
{
    [HideInInspector] public HashSet<GameObject> elementsInside;
    [HideInInspector] public int enterCounter;
    [HideInInspector] public int leaveCounter;
    GameObject side;

    void Start()
    {
        elementsInside = new HashSet<GameObject>();
        side = FindObjectOfType<Side>().gameObject;
    }

    public void AddElement(GameObject element)
    {
        elementsInside.Add(element);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Throwable")
        {
            elementsInside.Add(collision.gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Throwable")
        {
            elementsInside.Remove(collision.gameObject);
        }
    }
}
