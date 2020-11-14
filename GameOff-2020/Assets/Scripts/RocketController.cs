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
    private float DefaultRocketForce;
    public float rocketForce = 20f;
    public float movementX = 0f;
    public float maxYVelocity = 5f;
    public float maxXVelocity = 5f;
    public float highScore;
    public LevelManager LevelManagerScript;
    public Transform LeftSideCheckPoint;
    public Transform RightSideCheckPoint;
    public ParticleSystem ParticleSystem; // Stores the module in a local variable
    private int DefaultRocketParticleAmount;
    public int RocketParticleAmount = 10;
    public EffectsPostProcessing PostProcessingScript;
    //public GameObject birdPrefabLeft;
    //public GameObject birdPrefabRight;

    public int StarPowerUpMultiplier = 15;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = rb.position;
        DefaultRocketForce = rocketForce;
        DefaultRocketParticleAmount = RocketParticleAmount;
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
            //transform.rotation = Quaternion.identity;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(transform.rotation.z, 0, 1.5f));
            rb.velocity = new Vector2(rb.velocity.x / 3, rb.velocity.y);
            rb.position = new Vector2 (RightSideCheckPoint.position.x, rb.position.y);
        }
        if (collision.gameObject.CompareTag("RightChecks"))
        {
            //transform.rotation = Quaternion.identity;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(transform.rotation.z, 0, 3f));
            rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, 3f), rb.velocity.y);
            rb.position = new Vector2(LeftSideCheckPoint.position.x, rb.position.y);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.collider.gameObject.layer == LayerMask.NameToLayer("PowerUp")) // If hit layer
            {
                //Destroy(collision.gameObject);
                PostProcessingScript.StarPowerUp();
                StarPowerUp();
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
        PostProcessingScript.Die();
        StarPowerUpReset();
    }
    public void StarPowerUp()
    {
        if (rocketForce != DefaultRocketForce * StarPowerUpMultiplier)
        {
            rocketForce = rocketForce * StarPowerUpMultiplier;
        }
        if (RocketParticleAmount != DefaultRocketParticleAmount * (StarPowerUpMultiplier / 5))
        {
            RocketParticleAmount = RocketParticleAmount * (StarPowerUpMultiplier / 5);
        }
        //Physics2D.IgnoreCollision(birdPrefabLeft.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
        //Physics2D.IgnoreCollision(birdPrefabRight.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
    }
    public void StarPowerUpReset()
    {
        rocketForce = DefaultRocketForce;
        RocketParticleAmount = DefaultRocketParticleAmount;
        //Physics2D.IgnoreCollision(birdPrefabLeft.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
        //Physics2D.IgnoreCollision(birdPrefabRight.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
    }
}