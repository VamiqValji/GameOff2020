using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnicornScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float movement = 5f;
    public float MoveBy = 18f;

    public int MinSize = 1;
    public int MaxSize = 6;

    public int MinSpeed = 15;
    public int MaxSpeed = 25;

    private float randNum;
    private bool start = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        randNum = Random.Range(MinSize, MaxSize);
    }

    void FixedUpdate()
    {

        if (start == true)
        {
            movement = Random.Range(MinSpeed, MaxSpeed);

            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(randNum, randNum, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(-randNum, randNum, transform.localScale.z);
            }

            start = false;
        }

        if (transform.localScale.x > 0)
        {
            //rb.velocity = new Vector2(-birdMovement, rb.velocity.y);
            rb.velocity = Vector2.right * -movement * Time.deltaTime;
        }
        else
        {
            //rb.velocity = new Vector2(-birdMovement, rb.velocity.y);
            rb.velocity = Vector2.right * movement * Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LeftChecks"))
        {
            rb.position = new Vector2(rb.position.x + (MoveBy - (transform.localScale.x / 1.5f)), rb.position.y);
        }
        if (collision.gameObject.CompareTag("RightChecks"))
        {
            rb.position = new Vector2(rb.position.x - (MoveBy - (transform.localScale.x / 1.5f)), rb.position.y);
        }
    }
}
