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
            SpawnThrowable();
        }
    }

    private void SpawnThrowable()
    {
        Side side;
        if (sides[0].elementsInside.Count < sides[1].elementsInside.Count)
            side = sides[0];
        else if (sides[0].elementsInside.Count > sides[1].elementsInside.Count)
            side = sides[1];
        else
            side = sides[Random.Range(0, sides.Length)];
        GameObject element = prefabs[Random.Range(0, prefabs.Count)];
        element = Instantiate(element, side.transform.position, Quaternion.identity);
        element.GetComponent<Rigidbody2D>().mass = Random.Range(1, 10);
        side.AddElement(element);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer % 60 >= 5.0f)
        {
            SpawnThrowable();
            timer = 0.0f;
        }
    }
}
