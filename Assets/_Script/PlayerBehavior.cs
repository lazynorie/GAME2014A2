///By Jing Yuan Cheng 101257237
/// PlayerBehavior Script
/// 
/// Version 2.0
/// Last edited on Dec 11 2021
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    [Header("Touch Input")] 
    public Joystick joystick;
    
    [Header("Movement")] 
    public float horizontalForce;
    public float verticalForce;
    public bool isGrounded;
    public Transform groundOrigin;
    public float groundRadius;
    //public LayerMask groundLayerMask;
    public LayerMask groundLayerMask,blockLayerMask,enemyLayMask;
    [Range(0.1f,0.9f)]
    public float airControllfactor;

    [Header("Animation")] 
    public PlayerAnimationStates state;
    
    private Rigidbody2D _rigidbody2D;
    private Animator animatorcontroller;
    
    
    

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        animatorcontroller = GetComponent<Animator>();
        
    }

    void FixedUpdate()
    {
        Move();
        CheckIfGrounded();

        if (Input.GetKeyDown(KeyCode.G))
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal") + joystick.Horizontal;
       
        
        if (isGrounded)
        {
            //Keyboard Input
            float y = Input.GetAxis("Vertical") + joystick.Vertical;
            float jump = Input.GetAxisRaw("Jump") + ((UIController.jumpButtonDown)?1.0f:0.0f);
            //Check for flip 
            if (x != 0)
            {
                x = FlipAnimation(x);
                animatorcontroller.SetInteger("AnimationState",(int)PlayerAnimationStates.RUN);//Run state
                state = PlayerAnimationStates.RUN;
            }
            else
            {
                animatorcontroller.SetInteger("AnimationState", (int)PlayerAnimationStates.IDLE);//Idle state
                state = PlayerAnimationStates.IDLE;

            }

            //Touch Input
            /*
             Vector2 worldTouch = new Vector2();
            foreach (var touch in Input.touches)
            {
                worldTouch = Camera.main.ScreenToWorldPoint(touch.position);
            }*/

            float horizontalMoveForce = x * horizontalForce;
            float jumpMoveForce = jump * verticalForce;

            float mass = _rigidbody2D.mass * _rigidbody2D.gravityScale;
        
            _rigidbody2D.AddForce(new Vector2(horizontalMoveForce, jumpMoveForce) * mass);
            _rigidbody2D.velocity *= 0.90f;//Scaling/Stopping
        }
        else //Air Control
        {
            animatorcontroller.SetInteger("AnimationState",(int)PlayerAnimationStates.JUMP);//JUMP state
            state = PlayerAnimationStates.JUMP;
            
            if (x != 0)
            {
                x = FlipAnimation(x);
                
                float horizontalMoveForce = x * horizontalForce * airControllfactor;
                float mass = _rigidbody2D.mass * _rigidbody2D.gravityScale;
                
                _rigidbody2D.AddForce(new Vector2(horizontalMoveForce, 0.0f) * mass);

            }
        }
       
    }
    
    private void CheckIfGrounded()
    { 
        RaycastHit2D hitPlatform =
                Physics2D.CircleCast(groundOrigin.position, groundRadius, Vector2.down, groundRadius, groundLayerMask);
        RaycastHit2D hitBlock =
            Physics2D.CircleCast(groundOrigin.position, groundRadius, Vector2.down, groundRadius, blockLayerMask);
        RaycastHit2D hitEnemy =
            Physics2D.CircleCast(groundOrigin.position, groundRadius, Vector2.down, groundRadius, enemyLayMask);
        isGrounded = (hitPlatform||hitBlock||hitEnemy) ? true : false;
    }

    private float FlipAnimation(float x)
    {
        //depending on direction scale across the x-axis either 1 or -1
        x = (x > 0) ? 1 : -1;
        transform.localScale = new Vector3(x, 1.0f);
        return x;
    }
    
    
  

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(other.transform);
        }
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(null);
        }
    }
    
    
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundOrigin.position,groundRadius);
    }
    
}
    