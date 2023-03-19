using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    Vector2 motionVector;
    public Vector2 lastMotionVector;
    Animator animator;
    [SerializeField] float speed;
    [SerializeField] KeyCode left;
    [SerializeField] KeyCode right;
    [SerializeField] KeyCode up;
    [SerializeField] KeyCode down;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        Vector3 pos = transform.position;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKey(left))
        {
            rigidbody2d.velocity = new Vector2(-speed, rigidbody2d.velocity.y);
        }
        else if(Input.GetKey(right))
        {
            rigidbody2d.velocity = new Vector2(speed, rigidbody2d.velocity.y);
        }
        else
        {
            rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
        }

        if(Input.GetKey(up))
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, speed);
        }
        else if(Input.GetKey(down))
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, -speed);
        }
        else
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, 0);
        }

        float horizontal = transform.position.x;
        float vertical = transform.position.y;

        motionVector = new Vector2(
            horizontal,
            vertical
            );

        if (horizontal != 0 || vertical != 0)
        {
            lastMotionVector = new Vector2(horizontal, vertical).normalized;
        }

        animator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
    }
}