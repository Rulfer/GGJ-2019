using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    Transform house;
    [SerializeField] private flickeringLight flicker = null;


    private void Start()
    {
        house = this.transform.parent;
    }

    private void Update()
    {
        //this.transform.rotation = Quaternion.Euler(0, 0, -house.transform.rotation.eulerAngles.z);
        this.transform.eulerAngles = new Vector3(0, 0, -house.transform.rotation.z);

        //Debug.Log( house.transform.localEulerAngles.z);

        if (flicker == null)
            return;

        float zAngle = 0;

        if (house.transform.localEulerAngles.z > 160 && house.transform.localEulerAngles.z < 360)
            zAngle = 360 % house.transform.localEulerAngles.z;

        else if (house.transform.localEulerAngles.z > 0 && house.transform.localEulerAngles.z < 180)
            zAngle = house.transform.localEulerAngles.z;

        if (zAngle < 5)
            return;

        flicker.CampfireIntensityFlickerValue = zAngle - 5;
        flicker.CampfireRangeFlickerValue = (zAngle - 5) / 2;
    }
}
