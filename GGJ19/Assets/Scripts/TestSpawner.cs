using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabs = new List<GameObject>();
    private Side[] sides;
    float timer = 0.0f;

    void Start()
    {
        sides = FindObjectsOfType<Side>();
        for(int i = 0; i < 10; i++)
        {
            spawnThrowable();
        }
    }

    private void spawnThrowable()
    {
        Transform transform = sides[Random.Range(0, sides.Length)].transform;
        GameObject element = prefabs[Random.Range(0, prefabs.Count)];
        element.GetComponent<Rigidbody2D>().mass = Random.Range(1, 10);
        Instantiate(element, transform.position, Quaternion.identity);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer % 60 >= 4.0f)
        {
            spawnThrowable();
            timer = 0.0f;
        }
    }
}
