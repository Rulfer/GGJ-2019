using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    [SerializeField] private float delete_Position = -50f;
    private float move_Speed = 1f;

    private void Awake()
    {
        move_Speed = Random.Range(0.2f, 0.4f);
    }

    private void FixedUpdate()
    {
        float newX = this.transform.position.x - move_Speed;
        this.transform.position = new Vector2(
            newX, this.transform.position.y);

        if (this.transform.position.x <= delete_Position)
            Destroy(this.gameObject);
    }
}
