using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float timeToIncrease = 1.5f; //this is the time between "speedups"
    float currentTime;  //to keep track
    
    float speedIncrement = 0.1f; //how much to increase the speed by

    public bool candoublejump;

    public bool dead = false;
    public bool onTube;
    public float moveSpeed;
    public float jumpForce;
    private Rigidbody2D myRigidbody;
    public LayerMask whatIsTube;
    public bool grounded;
    public LayerMask whatIsGround;
    bool gameStarted = false;
    private Collider2D myCollider;
    private Animator myAnimator;




     void Awake()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameStarted = true;
        }
    }
    void Start()
    {

        currentTime = Time.time + timeToIncrease;

        Screen.orientation = ScreenOrientation.Portrait;

        myRigidbody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        myAnimator = GetComponent<Animator>();
       

    }

   



    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            gameStarted = true;
        }
        if (dead || gameStarted == false)       
        return;

        if (Time.time >= currentTime)
        {
            moveSpeed += speedIncrement;
            currentTime = Time.time + timeToIncrease;
            if (moveSpeed == 3.5f)
            {
                moveSpeed = 3.5f;
            }
        }
        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

        Debug.Log(moveSpeed);


        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        



        if (Input.GetMouseButtonDown(0))
        {
            
           
            if (grounded)
            {
               
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                candoublejump = true;
               
            }
            else
            {
                if (candoublejump)
                {
                    candoublejump = false;
                   
                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                }


            }
            
        }
       
    
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        onTube = Physics2D.IsTouchingLayers(myCollider, whatIsTube);

       

        if (onTube){
            myAnimator.SetTrigger("Death");
            dead = true;
            GameControl.instance.PlayerDied ();

        }
    }
    
}











