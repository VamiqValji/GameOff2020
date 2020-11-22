using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
    private Transform target;

    public float speed = 5f;
    public float rotateSpeed = 200f;

    private Rigidbody2D rb;

    public GameObject deathExplosion;

    private float Timer;
    public float WaitingTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > WaitingTime)
        {
            Instantiate(deathExplosion, transform.position, deathExplosion.transform.rotation);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;

        direction.Normalize(); // Changes length of vector to 1, but does not change direction

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed; // angularVelocity is built into Unity

        rb.velocity = transform.up * speed;
    }
}
