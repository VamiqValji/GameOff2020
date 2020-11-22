using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteDelete : MonoBehaviour
{
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;    
    }

    void FixedUpdate()
    {
        if ((player.transform.position.y > transform.position.y + 120f) || player.transform.position.y < 5)
        {
            Destroy(gameObject);
        }
    }
}
