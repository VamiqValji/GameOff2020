using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private Vector3 respawnPoint;
    public float rocketRotation = 0.8f;
    public float rocketForce = 20f;
    public float movementX = 0f;
    public float maxYVelocity = 5f;
    public float maxXVelocity = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("x: " + rb.velocity.x);
        Debug.Log("y: " + rb.velocity.y);
    }

    public void FixedUpdate()
    {
        movementX = -(Input.GetAxis("Horizontal"));
        if ((Input.GetButton("Horizontal") == true) & (movementX != 0))
        {
            //rb.velocity = new Vector2(rb.velocity.x * movementX, speed);
            rb.AddForce(transform.up * rocketForce);
            //ConstantForce2D = (rocketForce) 
            //rb.rotation = rocketRotation;
            //transform.Rotate(transform.rotation.x, transform.rotation.y, transform.rotation.z * rocketRotation);
            transform.Rotate(0.0f, 0.0f, rocketRotation * movementX * Time.deltaTime, Space.Self);
            // MAX OUT VELOCITY
            if (rb.velocity.y > maxYVelocity)
            {
                rb.velocity = new Vector2(rb.velocity.x, maxYVelocity);
            }
            //if (rb.velocity.y < -maxYVelocity)
            //{
            //    rb.velocity = new Vector2(rb.velocity.x, -maxYVelocity);
            //}
            if (rb.velocity.x > maxXVelocity)
            {
                rb.velocity = new Vector2(maxXVelocity, rb.velocity.y);
            }
            if (rb.velocity.x < -maxXVelocity)
            {
                rb.velocity = new Vector2(-maxXVelocity, rb.velocity.y);
            }
            if (rb.velocity.x != 0f)
            {
                //rb.velocity = new Vector2(-movementX * 5, rb.velocity.y);
                rb.AddForce(transform.right * movementX * 1.5f);
            }
        }
    }
}
