using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform Gun;
    [SerializeField] Vector2 deathKick=new Vector2(10f,10f);
    
     bool IsAlive=true;
    float TherFiresGravity;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D MyBodyCollider;
    BoxCollider2D MyFeet;    
    void Start()
    {
        
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        MyBodyCollider = GetComponent<CapsuleCollider2D>();
        TherFiresGravity=myRigidbody.gravityScale;
        MyFeet = GetComponent<BoxCollider2D>();
        
    }

    void Update()
    {
        if(!IsAlive){return;}
        Run();
        FlipSprite();
        ClimbLadder();
        Die();
    }

    void OnMove(InputValue value)
    {
        if(!IsAlive){return;}
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if(!IsAlive){return;}
        if (!MyFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return;}
        
        if(value.isPressed)
        {
            // do stuff
            myRigidbody.velocity += new Vector2 (0f, jumpSpeed);
        }
    }

    void OnFire(InputValue value){
         if(!IsAlive){return;}
        Instantiate(bullet,Gun.position,transform.rotation);
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2 (moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("IsRuning", playerHasHorizontalSpeed);

    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }

    void ClimbLadder()
    {
        if (!MyFeet.IsTouchingLayers(LayerMask.GetMask("Climbing"))) { 
            myRigidbody.gravityScale=TherFiresGravity;
            myAnimator.SetBool("IsClimbing", false);

            return;
        }
        myRigidbody.gravityScale=0;
        Vector2 climbVelocity = new Vector2 (myRigidbody.velocity.x, moveInput.y * climbSpeed);
        myRigidbody.velocity = climbVelocity;
        bool playerHasVerticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("IsClimbing", playerHasVerticalSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        Die();
    }

    void Die(){
       
        if(MyBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enamies","Spikes"))){
           IsAlive=false;
           myAnimator.SetTrigger("Dying");
           myRigidbody.velocity=deathKick; 
           FindObjectOfType<GameSessiom>().ProcessPlayerDeath();
        }
    }

}
