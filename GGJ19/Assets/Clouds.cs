using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    [SerializeField] private GameObject cloud = null;

    [SerializeField] private float max_sky_height = 0;
    [SerializeField] private float min_sky_height = 0;

    [SerializeField] private float min_sky_size = 1f;
    [SerializeField] private float max_sky_size = 2f;

    [SerializeField] private float spawn_interval = 2f;
    [SerializeField] private float spawn_point = 54f;

    private float timer = 0;

    private void Start()
    {
        timer = spawn_interval;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= spawn_interval)
        {
            timer = 0;

            float y_Pos = Random.Range(min_sky_height, max_sky_height);
            float randomScale = Random.Range(min_sky_size, max_sky_size);
            GameObject new_Cloud = Instantiate(cloud, new Vector2(50, y_Pos), Quaternion.identity);
            new_Cloud.transform.localScale = new Vector2(randomScale, randomScale);
        }
    }
}
