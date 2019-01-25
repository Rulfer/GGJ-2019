using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : MonoBehaviour
{
    public bool isPlayerOne = false;

    [SerializeField] private float speed_Modifier;
    [SerializeField] private float max_Speed;
    private float currentSpeed = 0;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if(isPlayerOne)
        {
            PlayerOneMove();
        }
        else
        {
            PlayerTwoMove();
        }
    }

    private void PlayerOneMove()
    {
        if (Input.GetKey(KeyCode.A))
        {
            currentSpeed -= speed_Modifier * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {

            currentSpeed += speed_Modifier * Time.deltaTime;
        }
        else
        {
            if (currentSpeed > 0.01 || currentSpeed < -0.01)
            {
                if (currentSpeed > 0.01)
                    currentSpeed -= speed_Modifier * Time.deltaTime;
                else
                    currentSpeed += speed_Modifier * Time.deltaTime;
            }
            else
                currentSpeed = 0;
        }

        this.transform.localPosition = new Vector2(this.transform.localPosition.x + currentSpeed, this.transform.localPosition.y);
    }

    private void PlayerTwoMove()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (currentSpeed < -max_Speed)
                currentSpeed -= speed_Modifier * Time.deltaTime;
            else
                currentSpeed = -max_Speed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (currentSpeed < max_Speed)
                currentSpeed += speed_Modifier * Time.deltaTime;
            else
                currentSpeed = max_Speed;
        }
        else
        {
            if (currentSpeed > 0.01 || currentSpeed < -0.01)
            {
                if (currentSpeed > 0.01)
                    currentSpeed -= speed_Modifier * Time.deltaTime;
                else
                    currentSpeed += speed_Modifier * Time.deltaTime;
            }
            else
                currentSpeed = 0;
        }

        this.transform.localPosition = new Vector2(this.transform.localPosition.x + currentSpeed, this.transform.localPosition.y);
    }
}
