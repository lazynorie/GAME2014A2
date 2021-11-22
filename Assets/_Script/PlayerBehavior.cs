///By Jing Yuan Cheng 101257237
/// PlayerBehavior Script
/// this script is about player movement and physic 
/// Version 1.0
/// Last edited on Nov 21 2021
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    [Header("Movement")] 
    public float horizontalForce;
    public float verticalForce;
    public bool isGrounded;
    
    private Rigidbody2D _rigidbody2D;
    
    

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
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
        if (isGrounded)
        {
            float deltaTime = Time.deltaTime;
        
            //Keyboard Input
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            float jump = Input.GetAxisRaw("Jump");

            //Touch Input
            Vector2 worldTouch = new Vector2();
            foreach (var touch in Input.touches)
            {
                worldTouch = Camera.main.ScreenToWorldPoint(touch.position);
            }

            float horizontalMoveForce = x * horizontalForce * deltaTime;
            float jumpMoveForce = jump * verticalForce * deltaTime;

            float mass = _rigidbody2D.mass * _rigidbody2D.gravityScale;
        
            _rigidbody2D.AddForce(new Vector2(horizontalMoveForce, jumpMoveForce));
            _rigidbody2D.velocity *= 0.99f;//Scaling/Stopping
        }
       
    }

    private void CheckIfGrounded()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = false;
    }
}
    