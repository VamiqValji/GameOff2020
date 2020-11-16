using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float DemonMovement = 5f;
    public float MoveBy = 17f;
    public GameObject Fireball;

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
            rb.velocity = Vector2.right * -DemonMovement * Time.deltaTime;
            //Instantiate(Fireball, new Vector2(8, Player.transform.position.y + 10), transform.rotation);

        }
        else
        {
            rb.velocity = Vector2.right * DemonMovement * Time.deltaTime;
            //Instantiate(Fireball, new Vector2(-8, Player.transform.position.y + 10), transform.rotation);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LeftChecks"))
        {
            rb.position = new Vector2(rb.position.x + MoveBy, rb.position.y);
        }
        if (collision.gameObject.CompareTag("RightChecks"))
        {
            rb.position = new Vector2(rb.position.x - MoveBy, rb.position.y);
        }
    }
}
