using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : MonoBehaviour
{
    private PickUp pickUp;

    public bool isPlayerOne = false;

    [SerializeField] private float max_x_pos;
    [SerializeField] private float min_x_pos;
    [SerializeField] private float speed_Modifier;
    [SerializeField] private float max_Speed;
    [HideInInspector] public int throwCounter;
    private float currentSpeed = 0;

    private Rigidbody2D rigid;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private AudioSource source = null;
    [SerializeField] private AudioClip clip_Grab;
    [SerializeField] private AudioClip clip_Throw;

    // Use this for initialization
    void Awake()
    {
        source = this.GetComponent<AudioSource>();
        rigid = this.GetComponent<Rigidbody2D>();
        pickUp = this.transform.GetChild(0).GetComponent<PickUp>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        throwCounter = 0;
    }

    private void Update()
    {
        this.transform.eulerAngles = this.transform.parent.eulerAngles;
        Move();
        Interact();
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
        bool noInput = true;
        if (Input.GetKey(KeyCode.A))
        {
            if (currentSpeed < -max_Speed)
                currentSpeed -= speed_Modifier * Time.deltaTime;
            else
                currentSpeed = -max_Speed;
            animator.SetBool("move", true);
            this.transform.GetChild(0).localScale = new Vector2(-4.998992f, 4.998992f);

            noInput = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (currentSpeed < max_Speed)
                currentSpeed += speed_Modifier * Time.deltaTime;
            else
                currentSpeed = max_Speed;

            animator.SetBool("move", true);
            this.transform.GetChild(0).localScale = new Vector2(4.998992f, 4.998992f);

            noInput = false;
        }
        

        if(noInput)
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
            animator.SetBool("move", false);
        }

        //Restrict movement to be inside borders
        float nextPos = this.transform.localPosition.x + currentSpeed;
        if (nextPos > max_x_pos)
            nextPos = max_x_pos;
        else if (nextPos < min_x_pos)
            nextPos = min_x_pos;

        //Update player position
        this.transform.localPosition = new Vector2(nextPos, this.transform.localPosition.y);
    }

    private void PlayerTwoMove()
    {
        bool noInput = true;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (currentSpeed < -max_Speed)
                currentSpeed -= speed_Modifier * Time.deltaTime;
            else
                currentSpeed = -max_Speed;

            animator.SetBool("move", true);
            this.transform.GetChild(0).localScale = new Vector2(-4.998992f, 4.998992f);
            noInput = false;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (currentSpeed < max_Speed)
                currentSpeed += speed_Modifier * Time.deltaTime;
            else
                currentSpeed = max_Speed;

            animator.SetBool("move", true);
            this.transform.GetChild(0).localScale = new Vector2(4.998992f, 4.998992f);
            noInput = false;
        }

        if (noInput)
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
            animator.SetBool("move", false);
        }

        //Restrict movement to be inside borders
        float nextPos = this.transform.localPosition.x + currentSpeed;
        if (nextPos > max_x_pos)
            nextPos = max_x_pos;
        else if (nextPos < min_x_pos)
            nextPos = min_x_pos;

        //Update player position
        this.transform.localPosition = new Vector2(nextPos, this.transform.localPosition.y);
    }

    private void Interact()
    {
        if(isPlayerOne)
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                if(pickUp.held_Object == null)
                {
                    source.clip = clip_Grab;
                    source.Play();
                    pickUp.GrabItem(rigid);
                }
                else
                {
                    source.clip = clip_Throw;
                    source.Play();
                    rigid.mass = 0.0001f;
                    throwCounter += 1;
                    pickUp.ThrowItem(false);
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (pickUp.held_Object == null)
                {
                    source.clip = clip_Grab;
                    source.Play();
                    pickUp.GrabItem(rigid);
                }
                else
                {
                    source.clip = clip_Throw;
                    source.Play();
                    rigid.mass = 0.0001f;
                    throwCounter += 1;
                    pickUp.ThrowItem(true);
                }
            }
        }
    }
}
