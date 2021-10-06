using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    int lives;
    public SpriteRenderer render;
    public Animator animator;
    public float jumpHeight;
    public float velocity;
    public int state = 0;
    // Start is called before the first frame update
    void Start()
    {
        lives = 0;
        render = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.speed = 0.8f;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            state = 1;
            render.flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            state = 1;
            render.flipX = true;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            state = 2;
            Jump();
        }

        animator.SetInteger("action", state);
        float MoveX, MoveY, speed = 50f;
        MoveX = Input.GetAxis("Horizontal");
        MoveY = Input.GetAxis("Vertical");

        GetComponent<Rigidbody2D>().velocity = new Vector2(MoveX * speed, MoveY * speed);
    }

    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }
}
