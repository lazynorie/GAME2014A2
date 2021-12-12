using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public Transform BlockSpawnPoint;
    public bool canRespawn;
    // Start is called before the first frame update


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Lava"))
        {
            if (canRespawn)
            {
                transform.position = BlockSpawnPoint.transform.position;
            }
        }
    }
}
