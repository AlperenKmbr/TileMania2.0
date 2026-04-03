using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(10f,20f);
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    float gravityScaleAtStart;

    BoxCollider2D myBoxcollider;
    CapsuleCollider2D  myCapsulecollider;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    bool isAlive = true;
    bool isJumping = false;
   
   
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCapsulecollider = GetComponent<CapsuleCollider2D>();
        myBoxcollider = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRigidbody.gravityScale;
    }

    
    void Update()
    {
        if(!isAlive){return;}
        Run();
        FlipSprite();
        ClimbLadder();
        Die();
    }
   

    void OnMove(InputValue value)
    {
        if(!isAlive){return;}
        moveInput = value.Get<Vector2>();
       
    }
    void OnJump(InputValue value)
    {
        if (!myBoxcollider.IsTouchingLayers(LayerMask.GetMask("Ground","Ladder")) ) { return; }
        if (value.isPressed)
        {
            isJumping = true;
            myRigidbody.gravityScale = gravityScaleAtStart;
            myRigidbody.linearVelocity += new Vector2(0f, jumpSpeed);

            Invoke("ResetJumping", 0.3f);
        }
    }
    void ResetJumping() { isJumping = false; }

    void OnAttack(InputValue value)
    {
        if(!isAlive){return;}
        Instantiate(bullet,gun.position,transform.rotation);
    }


    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x*moveSpeed,myRigidbody.linearVelocity.y);
        myRigidbody.linearVelocity = playerVelocity;
        
        bool hasHorizontalspeed  = math.abs(myRigidbody.linearVelocity.x) >  math.EPSILON;
        myAnimator.SetBool("isRunning",hasHorizontalspeed);
       
       
       
    }
    void FlipSprite()
    {
        bool hasHorizontalspeed  = math.abs(myRigidbody.linearVelocity.x) >  math.EPSILON;
        if(hasHorizontalspeed)
        {
            transform.localScale = new Vector2(math.sign(myRigidbody.linearVelocity.x),1f);
        }
        
    }
   void ClimbLadder()
    {
        if (isJumping) { return; }
        bool hasVerticalspeed  = math.abs(myRigidbody.linearVelocity.y) >  math.EPSILON;
        if (!myBoxcollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            myRigidbody.gravityScale = gravityScaleAtStart;
            
            myAnimator.SetBool("isClimbing", false);

            return;
        }
        else
        {
            Vector2 climbVelocity = new Vector2(myRigidbody.linearVelocity.x, moveInput.y * climbSpeed);
            myRigidbody.linearVelocity = climbVelocity;
            myRigidbody.gravityScale = 0;
             myAnimator.SetBool("isClimbing",hasVerticalspeed);
        }
        
        
    }
     void Die()
    {
        if(myBoxcollider.IsTouchingLayers(LayerMask.GetMask("Enemies","Hazards")))
        {
            isAlive = false;
            myAnimator.SetTrigger("Dying");
            myRigidbody.linearVelocity = deathKick;
            FindAnyObjectByType<GameSessions>().ProcessPlayerDeath();
        }
    }

}
