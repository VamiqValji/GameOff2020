using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

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
    public int StarPowerUpMultiplier = 15;
    public GameObject triggerDeath;
    public ParticleSystem Effect;
    public int EffectAmount = 10;
    public GameObject EnemyDeathSound;
    public GameObject PlayerDeathSound;
    public GameObject StarPickup;
    public GameObject RespawnSound;
    public AudioSource BillySoundTrack;
    private float defaultPitch = 1f;
    public float starPitch = 1f;
    private bool canMove = true;
    public RocketSoundController RSC;

    //RespawnTimer

    public float respawnWaitingTime = 0.10f;
    public float respawnTimer;
    private bool respawn = false;

    //ResetRespawnTimer

    private float RRWaitingTime = 1f;
    private float RRTimer;
    private bool RR = true;

    // Cinemachine

    public CinemachineVirtualCamera cvc;
    private CinemachineBasicMultiChannelPerlin cbmcp;
    public float shakeTimer = 2f;
    public float shakeIntensity = 1f;

    // Animator

    public Animator controlsUI;
    public Animator speechBubble;
    public Animator scoreText;

    // UI

    public GameObject deathScreen;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = rb.position;
        DefaultRocketForce = rocketForce;
        DefaultRocketParticleAmount = RocketParticleAmount;
        cbmcp = cvc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cbmcp.m_AmplitudeGain = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (respawn == true)
        {
            respawnTimer += Time.deltaTime;
            if (respawnTimer > respawnWaitingTime)
            {
                respawn = false;
                respawnTimer = 0;
            }
        }

        if (RR == false)
        {
            RRTimer += Time.deltaTime;
            if (RRTimer > RRWaitingTime)
            {
                RR = true;
                RRTimer = 0;
            }
        }
    }
    public void FixedUpdate()
    {
        if (respawn == false && canMove == true)
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
            }
        }

        // CM Machine Shake

        if (movementX != 0f)
        {
            if (rocketForce == DefaultRocketForce) // star powerup NOT active
            {
                cbmcp.m_AmplitudeGain = Mathf.Lerp(cbmcp.m_AmplitudeGain, shakeIntensity, shakeTimer);
                //cbmcp.m_AmplitudeGain = shakeIntensity;
            }
            else // star powerup active
            {
                cbmcp.m_AmplitudeGain = Mathf.Lerp(cbmcp.m_AmplitudeGain, shakeIntensity * 1.5f, shakeTimer);
            }
        }
        else if (cbmcp.m_AmplitudeGain != 0f) // not pressing A or D, and shake not at 0
        {
            cbmcp.m_AmplitudeGain = Mathf.Lerp(cbmcp.m_AmplitudeGain, 0f, shakeTimer * 2);
            //cbmcp.m_AmplitudeGain = 0f;
        }

        // Controls UI

        if (transform.position.y < 10)
        {
            controlsUI.SetFloat("PlayerHeight", transform.position.y);
            speechBubble.SetFloat("PlayerHeight", transform.position.y);
            scoreText.SetFloat("PlayerHeight", transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 13) // Power Up
        {
            Destroy(collision.gameObject);
            PostProcessingScript.StarPowerUp();
            StarPowerUp();
            Effect.Emit(EffectAmount);
        }
        if (collision.gameObject.layer == 14) // Enemy
        {
            if (rocketForce != DefaultRocketForce) // Star power up active
            {
                Destroy(collision.gameObject);
                Instantiate(triggerDeath, transform.position, triggerDeath.gameObject.transform.rotation);
                //collision.attachedRigidbody.constraints = RigidbodyConstraints2D.None;
                //collision.gameObject.layer = 11;
                //Effect.Emit(EffectAmount / 3);
                Instantiate(EnemyDeathSound, transform.position, transform.rotation);
            }
            //else // Star power NOT up active
            //{

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
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(transform.rotation.z, 0, 1.5f));
            //rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, 1f), rb.velocity.y);
            rb.velocity = new Vector2(0f, rb.velocity.y);
            rb.position = new Vector2 (RightSideCheckPoint.position.x, rb.position.y);
        }
        if (collision.gameObject.CompareTag("RightChecks"))
        {
            //transform.rotation = Quaternion.identity;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(transform.rotation.z, 0, 3f));
            //rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, 1f), rb.velocity.y);
            rb.velocity = new Vector2(0f, rb.velocity.y);
            rb.position = new Vector2(LeftSideCheckPoint.position.x, rb.position.y);
        }
        if (rocketForce == DefaultRocketForce) // Star power up NOT active
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Die();
            }
        }
    }

    public void Die()
    {
        Instantiate(PlayerDeathSound, transform.position, transform.rotation);
        canMove = false;
        Time.timeScale = 0.5f;
        Invoke("ActualDie", 1f);
        deathScreen.SetActive(true);
        RSC.isDead = true;
        PostProcessingScript.DeathScreen();
        cbmcp.m_AmplitudeGain = Mathf.Lerp(cbmcp.m_AmplitudeGain, shakeIntensity * 2f, shakeTimer / 4);
    }
    public void ActualDie()
    {
        if (RR == true)
        {
            Time.timeScale = 1f;
            respawn = true;
            rb.position = respawnPoint;
            rb.rotation = 0f;
            rb.velocity = new Vector3(0, 0, 0);
            LevelManagerScript.PlayerDeath();
            PostProcessingScript.Die();
            StarPowerUpReset();
            deathScreen.SetActive(false);
            canMove = true;
            RSC.isDead = false;
            Instantiate(RespawnSound);
            //Destroy(GameObject.FindGameObjectWithTag("RespawnSoundEffect"), 0.8f);
            RR = false;
        }
    }
    public void StarPowerUp()
    {
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(transform.rotation.z, 0, 1.5f));
        if (rocketForce != DefaultRocketForce * StarPowerUpMultiplier)
        {
            rocketForce = rocketForce * StarPowerUpMultiplier;
        }
        if (RocketParticleAmount != DefaultRocketParticleAmount * (StarPowerUpMultiplier / 5))
        {
            RocketParticleAmount = RocketParticleAmount * (StarPowerUpMultiplier / 5);
        }
        Instantiate(StarPickup, transform.position, transform.rotation);
        BillySoundTrack.pitch = Mathf.Lerp(BillySoundTrack.pitch, starPitch, 3f * Time.deltaTime);
    }
    public void StarPowerUpReset()
    {
        rocketForce = Mathf.Lerp(rocketForce, DefaultRocketForce, 3f);
        //rocketForce = DefaultRocketForce;
        RocketParticleAmount = DefaultRocketParticleAmount;
        BillySoundTrack.pitch = Mathf.Lerp(BillySoundTrack.pitch, defaultPitch, 3f * Time.deltaTime);
    }
}