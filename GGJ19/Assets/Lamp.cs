using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    Transform house;

    private void Start()
    {
        house = this.transform.parent;
    }

    private void Update()
    {
        //this.transform.rotation = Quaternion.Euler(0, 0, -house.transform.rotation.eulerAngles.z);
        this.transform.eulerAngles = new Vector3(0, 0, -house.transform.rotation.z);
    }
}
