using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    PhotonView view;

    Rigidbody2D rigidbody2d;
    [SerializeField] float speed = 2f;
    [SerializeField] float runSpeed = 5f;
    Vector2 motionVector;
    public Vector2 lastMotionVector;
    bool running;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (view.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                running = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                running = false;
            }
        
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            motionVector.x = horizontal;
            motionVector.y = vertical;

            if (horizontal != 0 || vertical != 0)
            {
                lastMotionVector = new Vector2(horizontal, vertical).normalized;
            }
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rigidbody2d.velocity = motionVector * (running == true ? runSpeed : speed);
    }
}