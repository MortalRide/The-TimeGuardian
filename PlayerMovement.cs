using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;


    private Vector3 moveDirection;
    private Vector3 Velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;


    [SerializeField] private float jumpHeight;
    [SerializeField] private float longJumpHeight;

    private CharacterController controller;
    private Animator anim;

    public Slider healthbarPlayer;
  

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
       
    }

   
    private void Update()
    {
        if (healthbarPlayer.value <= 0)
        {
            return;
        }
        Move();
       
        if (Input.GetKeyDown(KeyCode.Mouse0) && moveSpeed == 0)
        {
           
            Attack();
        }
        
    }

    private void Move()
    {
        

        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if (isGrounded && Velocity.y < 0)
        {
            Velocity.y = -2f;

        }
        
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(moveX, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);



        if (isGrounded)
        {
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                //walk
                Walk();
                
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                //run
                Run();
            }
            else if (moveDirection == Vector3.zero)
            {
                //idle
                Idle();
            }
            
            moveDirection *= moveSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                
                LongJump();
            }
        }

        controller.Move(moveDirection * Time.deltaTime);

        Velocity.y += gravity * Time.deltaTime;
        controller.Move(Velocity * Time.deltaTime);
    }

    private void Idle()
    {
        moveSpeed = 0;
        anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    private void Run()
    {
        moveSpeed = runSpeed;
        anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
    }

    private void Jump()
    {
        Velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }

    private void LongJump()
    {
        Velocity.y = Mathf.Sqrt(longJumpHeight * -2 * gravity);
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");

    }
}
