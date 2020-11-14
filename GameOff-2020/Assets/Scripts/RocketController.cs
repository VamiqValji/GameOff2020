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
    public Transform LeftSideCheckPoint;
    public Transform RightSideCheckPoint;
    public ParticleSystem ParticleSystem; // Stores the module in a local variable
    public int RocketParticleAmount = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        //ParticleSystem.emission.enabled = false;
        //ParticleSystem.EmissionModule.enabled = false;
    }
    public void FixedUpdate()
    {
        movementX = -(Input.GetAxis("Horizontal"));
        if ((Input.GetButton("Horizontal") == true) & (movementX != 0))
        {
            ParticleSystem.Emit(RocketParticleAmount);
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
            rb.position = new Vector2 (RightSideCheckPoint.position.x, rb.position.y);
        }
        if (collision.gameObject.CompareTag("RightChecks"))
        {
            rb.position = new Vector2(LeftSideCheckPoint.position.x, rb.position.y);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.collider.gameObject.layer == LayerMask.NameToLayer("PowerUp")) // If hit layer
            {
                StarPowerUp();
                //RocketPowerUp = true;
            }
            else
            {
                Die();
            }
        }
    }
    public void Die()
    {
        rb.position = respawnPoint;
        rb.rotation = 0f;
        rb.velocity = new Vector3(0, 0, 0);
        LevelManagerScript.PlayerDeath();
    }
    public void StarPowerUp()
    {
        Debug.Log("Star hit");
        //Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}