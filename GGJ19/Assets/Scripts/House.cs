using UnityEngine;

public class House : MonoBehaviour
{
    GameObject house;
    [SerializeField] private float startAngularDrag = 100;
    [SerializeField] private float angularDragChangeRate = 10.0f;
    float timer;
 
    void Start()
    {
        house = FindObjectOfType<House>().gameObject;
        house.GetComponent<Rigidbody2D>().angularDrag = startAngularDrag;
        timer = 0.0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer % 60 >= angularDragChangeRate)
        {
            house.GetComponent<Rigidbody2D>().angularDrag /= 2;
            timer = 0.0f;
        }
    }
}
