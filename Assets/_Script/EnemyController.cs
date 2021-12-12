///By Jing Yuan Cheng 101257237
/// EnemyController Script
/// 
/// Version 1.0
/// Last edited on Dec 12 2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    
    [Header("Movement")]
    public float runForce;
    public Transform lookAheadPoint;
    public Transform lookInfrontPoint;
    public LayerMask groundLayerMask;
    public LayerMask blockLayerMask;
    public bool isGroundAhead;
    public bool isBlocked;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LookAhead();
        LookInfront();
        MoveEnemy();
    }

    private void LookInfront()
    {
        var hit = Physics2D.Linecast(transform.position, lookInfrontPoint.position, blockLayerMask);
        if (hit)
        {
            Flip();
        }
    }

    private void LookAhead()
    {
        var hit = Physics2D.Linecast(transform.position, lookAheadPoint.position, groundLayerMask);
        isGroundAhead = (hit) ? true : false;
    }


    private void MoveEnemy()
    {
        if (isGroundAhead)
        {
            _rigidbody2D.AddForce(Vector2.left*runForce*transform.localScale.x);
            _rigidbody2D.velocity *= 0.90f;
        }
        else
        {
            Flip();
        }
    }

    private void Flip()
    {
        transform.localScale =
            new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
    }
    //Events
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
    
    //Utilities
    private void OnDrawGizmos()
    {
       Gizmos.DrawLine(transform.position, lookAheadPoint.position);
       Gizmos.DrawLine(transform.position, lookInfrontPoint.position);
    }
}
