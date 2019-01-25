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
        Animate();
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
            if (currentSpeed < -max_Speed)
                currentSpeed -= speed_Modifier * Time.deltaTime;
            else
                currentSpeed = -max_Speed;
            animator.SetBool("move_right", true);
            this.transform.GetChild(0).localScale = new Vector2(-4.998992f, 4.998992f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (currentSpeed < max_Speed)
                currentSpeed += speed_Modifier * Time.deltaTime;
            else
                currentSpeed = max_Speed;

            animator.SetBool("move_right", true);
            this.transform.GetChild(0).localScale = new Vector2(4.998992f, 4.998992f);
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
            animator.SetBool("move_right", false);
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

            animator.SetBool("move_right", true);
            this.transform.GetChild(0).localScale = new Vector2(-4.998992f, 4.998992f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (currentSpeed < max_Speed)
                currentSpeed += speed_Modifier * Time.deltaTime;
            else
                currentSpeed = max_Speed;

            animator.SetBool("move_right", true);
            this.transform.GetChild(0).localScale = new Vector2(4.998992f, 4.998992f);
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
            animator.SetBool("move_right", false);
        }

        this.transform.localPosition = new Vector2(this.transform.localPosition.x + currentSpeed, this.transform.localPosition.y);
    }

    private void Animate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {

        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {

        }
        else
        {
            animator.SetBool("move_right", false);

        }
        //if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        //{
        //    animator.SetBool("move_right", true);
        //    this.transform.GetChild(0).localScale = new Vector2(4.998992f, 4.998992f);
        //}
        //else
        //    animator.SetBool("move_right", false);
    }
}
