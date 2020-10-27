using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rig;
    private BoxCollider2D boxCollider;
    public float speed = 8f;
    private float xVelocity;
    public float jumpForce;
    private float jumpTime;
    public float jumpHoldDuration = 0.1f;
    public bool jumpPressed;
    public bool isJumping;
    public bool isOnGround;
    public float footOffset = 0.4f;
    public float groundDistance = 0.8f;
    public LayerMask groundLayer;
    private List<Collider2D> inCollider = new List<Collider2D>();
    private int jumpCount = 2;
    public bool isWall;
    // Start is called before the first frame update
    void Start()
    {
        rig = this.GetComponent<Rigidbody2D>();
        boxCollider = this.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpCount>0)
        {
            jumpPressed = Input.GetButtonDown("Jump");
           
        }
       
        if (Input.GetKeyDown(KeyCode.K))
        {
            inCollider.ForEach(n => n.SendMessage("Use", SendMessageOptions.DontRequireReceiver));
        }
    }
    private void FixedUpdate()
    {
        PhysicsCheck();
        Run();
        Jump();
        Climb();
    }

    private void PhysicsCheck()
    {
        RaycastHit2D leftCheck = Raycast(new Vector2(-footOffset, 0), Vector2.down, groundDistance, groundLayer);
        RaycastHit2D rightCheck = Raycast(new Vector2(footOffset, 0), Vector2.down, groundDistance, groundLayer);
        RaycastHit2D wallLeftCheck = Raycast(new Vector2(-footOffset, -0.5f), Vector2.left, 0.5f, groundLayer);
        RaycastHit2D wallRightCheck = Raycast(new Vector2(footOffset, -0.5f), Vector2.right, 0.5f, groundLayer);
        /*if (boxCollider.IsTouchingLayers(groundLayer))
        {
            isOnGround = true;
        }*/
        if (leftCheck || rightCheck || isWall)
        {
            isOnGround = true;
        }
        else
        {
            isOnGround = false;
        }

        if (wallLeftCheck || wallRightCheck)
        {
            isWall = true;
        }
        else
        {
            isWall = false;
        }
    }

    private void Run()
    {
        xVelocity = Input.GetAxis("Horizontal");
         rig.velocity = new Vector2(xVelocity * speed, rig.velocity.y);
        
        //rig.AddForce(new Vector2(xVelocity * speed, 0), ForceMode2D.Impulse);
        FilpDirection();
    }
    private void FilpDirection()
    {
        if (xVelocity < 0)
        {
            this.transform.localScale = new Vector2(-1, 1);
        }
        if (xVelocity > 0)
        {
            this.transform.localScale = new Vector2(1, 1);
        }
    }


    private void  Jump()
    {
        if (jumpPressed &&!isJumping && isOnGround && jumpCount>0)
        {
            isJumping=true;
            isOnGround = false;
            jumpCount--;
            jumpPressed = false;
            //jumpTime = Time.time + jumpHoldDuration;
            rig.AddForce(new Vector2(rig.velocity.x, jumpForce), ForceMode2D.Impulse);
          
           
        }
        else if (jumpPressed && jumpCount ==1 && !isOnGround && isJumping)
        {
            rig.AddForce(new Vector2(rig.velocity.x, jumpForce*1.2f), ForceMode2D.Impulse);
            jumpPressed = false;
            jumpCount--;
          
        }
         if(isOnGround )
        {
            isJumping = false;
            jumpCount = 2;
        }
        
    }


    private void Climb()
    {
        if (isWall)
        {
            rig.gravityScale = 0;
            float yVelocity = Input.GetAxis("Vertical");
            rig.velocity = new Vector2(rig.velocity.x, yVelocity * speed);
        }
        else
        {
            rig.gravityScale = 1;
        }
       
    }
    private RaycastHit2D Raycast(Vector2 offset,Vector2 rayDirection,float length,LayerMask layer)
    {
        Vector2 pos = this.transform.position;
        RaycastHit2D hit = Physics2D.Raycast(pos + offset, rayDirection, length, layer);
        Color color = hit ? Color.red : Color.green;
        Debug.DrawRay(pos + offset, rayDirection * length, color);
        return hit;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        inCollider.Add(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inCollider.Remove(collision);
    }
}
