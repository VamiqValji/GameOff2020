using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;
    public float cloudMovement = 75f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.localScale.x > 0)
        {
            //rb.velocity = new Vector2(-birdMovement, rb.velocity.y);
            rb.velocity = Vector2.right * cloudMovement * Time.deltaTime;
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
