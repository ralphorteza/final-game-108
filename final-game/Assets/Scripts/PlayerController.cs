using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Start is called before the first frame update
    [Header("Movement")]
    //physics component for an object. not required for movement, but don't you just love gravity :)
    Rigidbody2D rb2;
    //user input for moving in the positice or negative in X direction
    private float horizontalInput;
    //a multiplier for how high you jump
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    //jump direction
    private float moveLeftRight;
    //private GroundCheck gc;

    private Vector2 playerVelocity;
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float sprintSpeed;
    private Vector2 m_Velocity = Vector2.zero;
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f; // how much to smooth out the movement

    private void Awake()
    {

        rb2 = GetComponent<Rigidbody2D>();
        //gc = GetComponent<GroundCheck>();
    }
    // Update is called once per frame
    void Update()
    {

        GetPlayerInput();

    }
    private void GetPlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if ((Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.D)))))
        {
            Sprint(horizontalInput);
        }
        else
        {
            Walk(horizontalInput);
        }


    }

    private void Jump()
    {

        //if (!gc.isGrounded())
        //{
        //    Debug.Log("IsGrounded");
        //    return;
        //}
        //else
        //{

        rb2.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        //}


    }
    private void Sprint(float horizontalInput)
    {
        moveLeftRight = horizontalInput * sprintSpeed;
        rb2.velocity = new Vector2(moveLeftRight, rb2.velocity.y);
    }

    private void Walk(float horizontalInput)
    {
        //move left or right based on player input and speed
        /*
         * Use Arrow Keys or A,D to move
         */
        moveLeftRight = horizontalInput * walkSpeed;
        Vector2 targetVelocity = new Vector2(moveLeftRight, rb2.velocity.y);
        rb2.velocity = Vector2.SmoothDamp(rb2.velocity, targetVelocity, ref m_Velocity, movementSmoothing);
        //rb2.velocity = new Vector2(moveLeftRight, rb2.velocity.y);

    }



}
