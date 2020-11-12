using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float birdMovement = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.localScale.x > 0) // Not negative
        {
            //rb.position = new Vector2(rb.position.x + (birdMovement * 1), rb.position.y);
            //rb.AddForce(transform.right * -birdMovement);
            //Debug.Log(rb.velocity.x);
            rb.velocity = new Vector2(-birdMovement, rb.velocity.y);
        }
        else // Negative
        {
            //rb.AddForce(transform.right * birdMovement);
            //Debug.Log(rb.velocity.x);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LeftChecks"))
        {
            rb.position = new Vector2(rb.position.x + 18f, rb.position.y);
        }
        if (collision.gameObject.CompareTag("RightChecks"))
        {
            rb.position = new Vector2(rb.position.x - 18f, rb.position.y);
        }
    }
}
