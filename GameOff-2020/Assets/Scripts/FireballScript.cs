using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float movement = 30f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.localScale.x > 0)
        {
            rb.velocity = Vector2.right * -movement * Time.deltaTime;
        }
        else
        {
            rb.velocity = Vector2.right * movement * Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LeftChecks"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("RightChecks"))
        {
            Destroy(gameObject);
        }
    }
}
