using System.Collections.Generic;
using UnityEngine;

public class Side : MonoBehaviour
{
    [HideInInspector] public HashSet<GameObject> elementsInside = new HashSet<GameObject>();
    [HideInInspector] public int enterCounter;
    [HideInInspector] public int leaveCounter;
    GameObject side;

    void Start()
    {
        side = FindObjectOfType<Side>().gameObject;
        enterCounter = 0;
        leaveCounter = 0;
    }

    public void AddElement(GameObject element)
    {
        elementsInside.Add(element);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Throwable")
        {
            enterCounter += 1;
            elementsInside.Add(collision.gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Throwable")
        {
            leaveCounter += 1;
            elementsInside.Remove(collision.gameObject);
        }
    }
}
