using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    [SerializeField] private Light dayLight;
    [SerializeField] private Light nightLight;

    [SerializeField] private GameObject sun;
    [SerializeField] private GameObject moon;

    [SerializeField] private float rotationSpeed = 10f;

    [SerializeField] private float lightIntensity = 2f;
    [SerializeField] private float fadeSpeed = 1f;

    [SerializeField] private float rotation_before_change = 180;
    [SerializeField] private float lastRotation = 180;

    private bool makeDay = false;
    private bool makeNight = false;
    private bool isDay = true;

    private void Start()
    {
        dayLight.intensity = lightIntensity;
        nightLight.intensity = 0;
    }

    private void FixedUpdate()
    {
        this.transform.Rotate(new Vector3(0, 0, rotationSpeed));
        lastRotation += rotationSpeed;

        if (lastRotation <= 0)
        {
            lastRotation = 360;


            if (isDay)
            {
                makeNight = true;
                sun.SetActive(false);
                moon.SetActive(true);
            }
            else
            {
                makeDay = true;
                sun.SetActive(true);
                moon.SetActive(false);
            }
            isDay = !isDay;
        }
    }


}
