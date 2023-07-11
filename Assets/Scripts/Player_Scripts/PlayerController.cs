using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator ani;
    [SerializeField] private Behaviour[] component;

    [Header ("Moving")]
    [SerializeField] GroundCheck check;
    private float moveInput;
    [SerializeField] private float runSpeed;
    [SerializeField]private bool isGrounded;
    private float jumpForce;
    [SerializeField] private float jumpHeight = 2f;

    [Header("Coyote Time")]
    [SerializeField] private float coyoteTime;
    private float coyoteCounter;

    [Header("climb ladder")]
    [SerializeField] private float climbSpeed;
    private bool isClimbing;
    public bool IsClimbing
    {
        get { return isClimbing; }
        //set { isClimbing = value; }
    }
    [SerializeField] private bool isLadder;
    private float verticalInput;

    [Header("OnPlatformMoving")]
    public bool isOnPlatform;
    public Rigidbody2D platformRb;

    [Header("Sound")]
    [SerializeField] AudioClip jumpSound;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        isOnPlatform = false;
    }

    private void Start()
    {
        jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rb.gravityScale));
    }

    private void FixedUpdate()
    {
        if (DialogueManager.isMessageActive)
        {
            rb.velocity = new Vector2(0,rb.velocity.y);
            return;
        }

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
        else if(!isClimbing && !isOnPlatform)
        {
            rb.gravityScale = 2.8f;
        }

    }

    void Update()
    {
        if (DialogueManager.isMessageActive)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            ani.SetBool("isGround", true);
            ani.SetBool("isRunning", false);
            ani.SetBool("isJump", false);
            return;
        }

        moveInput = Input.GetAxisRaw("Horizontal");

        if (isOnPlatform)
        {
            rb.velocity = new Vector2(moveInput * runSpeed + platformRb.velocity.x, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(moveInput * runSpeed, rb.velocity.y);
        }

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
            if (isGrounded && !isClimbing)
            {
                SetGravetiScale(2.8f);
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                SoundManager.instance.PlaySound(jumpSound);

            }
            else if (coyoteCounter > 0 && !isGrounded)
            {

                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                coyoteCounter = 0;
                SoundManager.instance.PlaySound(jumpSound);
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
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground") && isGrounded)
    //    {

    //    }

    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder") && isClimbing == true && verticalInput!=0)
        {
            transform.position = new Vector2(collision.gameObject.transform.position.x, transform.position.y);
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

    public bool canAttack()
    {
        return rb.velocity.y == 0f;
    }

    public bool IsMove()
    {
        return rb.velocity.x != 0 || rb.velocity.y!=0;
    }

    public void SetMoving(float value1,float value2)
    {
        rb.velocity = new Vector2(value1, value2);
    }

    public void SetGravetiScale(float _value)
    {
        rb.gravityScale = _value;
    }

    public bool canChangeCamera()
    {
        return !(!isClimbing && isLadder);
    }

    private void updateAnimations()
    {   
        // animaition running
        if (rb.velocity.x!=0 && isGrounded && moveInput!=0)
        {
            ani.SetBool("isRunning", true);

        }
        else
        {
            ani.SetBool("isRunning", false);

        }
        //Animation jumping
        if (rb.velocity.y !=0 && !isGrounded)
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
            if (verticalInput != 0) ani.speed = 1.1f;
            else ani.speed = 0f;


        }
        else
        {
            ani.speed = 1;
            ani.SetBool("isClimb", false);

        }
    }

}
