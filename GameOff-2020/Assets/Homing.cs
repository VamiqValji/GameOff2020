using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
    private Transform target;

    public float speed = 5f;
    public float rotateSpeed = 200f;

    private Rigidbody2D rb;

    private float initialPositionY;

    // Start is called before the first frame update
    void Start()
    {
        initialPositionY = transform.position.y;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log(target);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < initialPositionY + 1f)
        {
            Vector2 direction = (Vector2)target.position - rb.position;

            direction.Normalize(); // Changes length of vector to 1, but does not change direction

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed; // angularVelocity is built into Unity

            rb.velocity = transform.up * speed;
        }
    }
}
