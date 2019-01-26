using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class House : MonoBehaviour
{
    GameObject house;
    private Side right;
    private Side left;
    private float startAngularDrag = 100;
    private float angularDragChangeRate = 15.0f;
    private float victoryAngle = 20.0f;
    float timer;
 
    void Start()
    {
        house = FindObjectOfType<House>().gameObject;
        house.GetComponent<Rigidbody2D>().angularDrag = startAngularDrag;
        foreach(Side side in FindObjectsOfType<Side>())
        {
            if (side.name.ToLower().Contains("left"))
                left = side;
            else
                right = side;
        }
        timer = 0.0f;
    }

    private void Update()
    {
        AdjustAngularDrag();
        CheckGameEnd();
    }

    private void AdjustAngularDrag()
    {
        timer += Time.deltaTime;
        if (timer % 60 >= angularDragChangeRate)
        {
            house.GetComponent<Rigidbody2D>().angularDrag /= 2;
            timer = 0.0f;
        }
    }

    private void CheckGameEnd()
    {
        float zAngle = house.transform.eulerAngles.z;
        if (zAngle >= victoryAngle && zAngle <= 360.0f - victoryAngle)
        {
            if (zAngle <= 180.0f)
            {
                Debug.Log("Right side wins!");
            }
            else if (zAngle > 180.0f)
            {
                Debug.Log("Left side wins!");
            }
            Debug.Log("Right side threw " + right.leaveCounter + " elements and has " + right.elementsInside.Count + " element(s).");
            Debug.Log("Left side threw " + left.leaveCounter + " elements and has " + left.elementsInside.Count + " element(s).");
        }
        if (house.transform.position.y < -20)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
