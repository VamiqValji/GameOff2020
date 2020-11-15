using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBoss : MonoBehaviour
{
    Transform player;
    public float Distance = 10f;

    private bool Active = false;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Active == true)
        {
            transform.localPosition = new Vector3(player.position.x, player.position.y + Distance, 0);
        }
    }
    
    public void Activation()
    {
        if (Active == false)
        {
            Active = true;
        }
        else
        {
            Active = false;
        }
    }
}
