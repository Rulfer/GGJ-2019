using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private GameObject img_can_pick_up = null;


    private List<GameObject> objects_to_pick_up = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision hit");

        if(collision.transform.tag.Equals(""))
    }
}
