///By Jing Yuan Cheng 101257237
/// MovingPlatformController Script
/// 
/// Version 1.0
/// Last edited on Dec 11 2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    [Header("Movement")] public MovingPlatformDirection direction;

    [Range(0.1f, 10.0f)]
    public float speed;
    [Range(1.0f, 20.0f)]
    public float distance;
    
    [Range(0.05f, 0.1f)]
    public float distanceOffset;

    public bool isLooping;

    private Vector2 startingPosition;
    private bool isMoving;
    
    
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
        if (isLooping)
        {
            isMoving = true;
        }
    }

    private void MovePlatform()
    {
        float pingPongValue = (isMoving) ? Mathf.PingPong(Time.time * speed, distance) : distance;
       

        if((!isLooping) && (pingPongValue >= distance - distanceOffset))
        {
            isMoving = false;
        }
        
        switch (direction)
        {
            case MovingPlatformDirection.HORIZONTAL:
                transform.position = new Vector2(startingPosition.x + pingPongValue,
                    transform.position.y);
                break;
            case MovingPlatformDirection.VERTICAL:  
                transform.position = new Vector2(transform.position.x,startingPosition.y + pingPongValue);
                break;
            case MovingPlatformDirection.DIAGONAL_UP:
                transform.position = new Vector2(startingPosition.x + pingPongValue,
                    startingPosition.y + pingPongValue);
                break;
            case MovingPlatformDirection.DIAGONAL_DOWN:
                transform.position = new Vector2(startingPosition.x + pingPongValue,
                    startingPosition.y - pingPongValue);
                break;
            
        }
      
    }
}
