///By Jing Yuan Cheng 101257237
/// EnemyController Script
/// 
/// Version 1.0
/// Last edited on Dec 12 2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Rigidbody2D playerRigidbody2D;
    public PlayerBehavior player;
    private GameObject scoreManager;
    private ScoreManager scoreM;
    [Header("Movement")]
    public float runForce;
    public Transform lookAheadPoint;
    public Transform lookInfrontPoint;
    public LayerMask groundLayerMask, blockLayerMask, PlayerMask;
    public bool isGroundAhead;
    public bool isBlocked;

    public float topRadius;
    public Transform topOrigin;
    public LayerMask topLayerMask;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        playerRigidbody2D = player.GetComponent<Rigidbody2D>();
        scoreManager = GameObject.Find("ScoreManager");
        scoreM = scoreManager.GetComponent<ScoreManager>();


    }

    

    // Update is called once per frame
    void FixedUpdate()
    {
        getHurt();
        LookAhead();
        LookInfront();
        MoveEnemy();
    }

    private void LookInfront()
    {
        var hit = Physics2D.Linecast(transform.position, lookInfrontPoint.position, blockLayerMask);
        var hitplayer = Physics2D.Linecast(transform.position, lookInfrontPoint.position, PlayerMask);
        if (hit)
        {
            Flip();
        }

        if (hitplayer)
        {
            player.playerGetHitEvent.Invoke();
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
       Gizmos.DrawWireSphere(topOrigin.position,topRadius);
    }

    public void getHurt()
    {
        RaycastHit2D hurt =
            Physics2D.CircleCast(topOrigin.position, topRadius, Vector2.down, topRadius, topLayerMask);
        if (hurt)
        { 
            playerRigidbody2D.AddForce(new Vector2(0,500));
            scoreM.score += 100;
            Destroy(this.gameObject);
        }
    }
}
