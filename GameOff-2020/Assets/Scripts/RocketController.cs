using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private Vector3 respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal") == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }
    }

    public void FixedUpdate()
    {
        
    }
}
