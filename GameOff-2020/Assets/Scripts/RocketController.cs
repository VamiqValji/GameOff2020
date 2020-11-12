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
    public float highScore;
    public LevelManager LevelManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = rb.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void FixedUpdate()
    {
        movementX = -(Input.GetAxis("Horizontal"));
        if ((Input.GetButton("Horizontal") == true) & (movementX != 0))
        {
            rb.AddForce(transform.up * rocketForce);
            transform.Rotate(0.0f, 0.0f, rocketRotation * movementX * Time.deltaTime, Space.Self);
            // MAX OUT VELOCITY
            if (rb.velocity.y > maxYVelocity)
            {
                rb.velocity = new Vector2(rb.velocity.x, maxYVelocity);
            }
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
            //if (rb.rotation < 30f || rb.rotation > -30f)
            //{
            //    transform.Rotate(0.0f, 0.0f, rb.velocity.x * rocketRotation * movementX * Time.deltaTime, Space.Self);
            //}
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Checks"))
        {
            Die();
        }
        if (collision.gameObject.CompareTag("LeftChecks"))
        {
            rb.position = new Vector2 (rb.position.x + 18f, rb.position.y);
        }
        if (collision.gameObject.CompareTag("RightChecks"))
        {
            rb.position = new Vector2(rb.position.x -18f, rb.position.y);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }
    public void Die()
    {
        rb.position = respawnPoint;
        rb.rotation = 0f;
        rb.velocity = new Vector2(0, 0);
        LevelManagerScript.PlayerDeath();
    }
}