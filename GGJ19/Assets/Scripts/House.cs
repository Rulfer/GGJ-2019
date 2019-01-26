using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    GameObject house;
    private float startAngularDrag = 100;
    private float angularDragChangeRate = 15.0f;
    float timer;
 
    void Start()
    {
        house = FindObjectOfType<House>().gameObject;
        house.GetComponent<Rigidbody2D>().angularDrag = startAngularDrag;
        timer = 0.0f;
    }

    private void Update()
    {
        AdjustAngularDrag();
    }

    private void AdjustAngularDrag()
    {
        timer += Time.deltaTime;
        if (timer % 60 >= angularDragChangeRate)
        {
            house.GetComponent<Rigidbody2D>().angularDrag /= 1.5f;
            timer = 0.0f;
        }
    }
}
