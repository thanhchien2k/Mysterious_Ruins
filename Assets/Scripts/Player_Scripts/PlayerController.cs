using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator ani;

    [Header ("Moving")]
    [SerializeField] GroundCheck check;
    private float moveInput;
    [SerializeField] private float runSpeed;
    [SerializeField]private bool isGrounded;
    private float jumpForce;
    public float jumpHeight = 2f;

    [Header("Coyote Time")]
    [SerializeField] private float coyoteTime;
    private float coyoteCounter;

    [Header("climb ladder")]
    [SerializeField] private float climbSpeed;
    [SerializeField]private bool isClimbing;
    public bool IsClimbing
    {
        get { return isClimbing; }
        //set { isClimbing = value; }
    }
    [SerializeField] private bool isLadder;
    private float verticalInput;
    


    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        
        // tinh luc de nhay
        

    }
    private void Start()
    {
        jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rb.gravityScale));
    }

    // Update is called once per frame



    private void FixedUpdate()
    {
       
        isGrounded = check.groundCheck;
        SmoothJump();

        if (isGrounded)
        {
 
            if (rb.velocity.y>0)
            {
                //coyoteCounter = 0;
            }
            else 
            {
                coyoteCounter = coyoteTime;
            }

        }
        else
        {
                coyoteCounter -= Time.deltaTime;
        }

        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, verticalInput * climbSpeed);
            //rb.velocity = new Vector2(0f, rb.velocity.y);
        }
        else
        {
            rb.gravityScale = 2.8f;
        }

    }

    void Update()
    {
        // 
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * runSpeed, rb.velocity.y);

        // ktra dk flip player

        if (moveInput != 0) {
            if(moveInput >0)
            {
                playerFlip(1);
            }
            else
            {
                playerFlip(-1);
            }
        }
        // ktra dieu kien nhay
        


        if (Input.GetKeyDown(KeyCode.Space))
        {
            isClimbing = false;
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            }
            else if (coyoteCounter > 0 && !isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                coyoteCounter = 0;

            } 
        }

        // climbing ladder
        verticalInput = Input.GetAxisRaw("Vertical");

        if (isLadder && Mathf.Abs(verticalInput) > 0f)
        {
            isClimbing = true;
            
        }


        // update animation cho player
        updateAnimations();

        

}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
        if(isGrounded && collision.CompareTag("Ground"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder") && isClimbing && verticalInput!=0)
        {
            transform.position = new Vector2(collision.transform.position.x, transform.position.y);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isClimbing = false;
            isLadder = false;
        }
    }

    private void SmoothJump()
    {
        if (isGrounded) return ;

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (5 - 1) * Time.deltaTime; // tang van toc roi

        }
        else if (rb.velocity.y > 0 && !(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (5 - 1) * Time.deltaTime; // giam do cao khi ko giu nut space

        }

    }

    private void playerFlip(float scale)
    {
         
        transform.localScale = new(scale, 1, 1);
    }

    public bool canRunAttack()
    {
        return isGrounded && moveInput != 0;
    }

    public bool isMove()
    {
        return rb.velocity.x != 0 || rb.velocity.y!=0;
    }

    public void setMoving(float value1,float value2)
    {
        rb.velocity = new Vector2(value1, value2);
    }

    public bool canChangeCamera()
    {
        return ( isClimbing || (!isLadder && (rb.velocity.y == 0|| isGrounded||coyoteCounter>=0)) );
    }

    private void updateAnimations()
    {   
        // animaition running
        if (rb.velocity.x!=0 && isGrounded )
        {
            ani.SetBool("isRunning", true);

        }
        else
        {
            ani.SetBool("isRunning", false);

        }
        //Animation jumping
        if (rb.velocity.y !=0)
        {
            ani.SetBool("isJump", true);
        }
        else
        {
            ani.SetBool("isJump", false);
        }
        ani.SetBool("isGround", isGrounded);

        if (!isGrounded)
        {
            if (rb.velocity.y > 0)
            {
                ani.SetFloat("Blend", 0);

            }
            else if (rb.velocity.y < 0)
            {
                ani.SetFloat("Blend", 1);

            }
        }

        // animation climb ladder
        if (isClimbing)
        {
            ani.SetBool("isClimb", true);
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) ani.speed = 1.6f;
            else
            {
                ani.speed = 0;
            }
        }
        else
        {
            ani.speed = 1;
            ani.SetBool("isClimb", false);

        }
    }

}
