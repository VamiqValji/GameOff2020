using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject FireballLeft;
    public GameObject FireballRight;

    //public FireballScript FireballScript;

    private float Timer = 10f;
    public int WaitingTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > WaitingTime)
        {
            Shoot();
            Timer = 0;
        }
    }

    private void Shoot()
    {
        if (transform.localScale.x > 0)
        {
            Instantiate(FireballLeft, new Vector2(6, transform.position.y - 0.4f), transform.rotation);
        }
        else
        {
            Instantiate(FireballRight, new Vector2(-6, transform.position.y - 0.4f), transform.rotation);
        }
    }

    private void OnCollisionEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Demon"))
        {
            Destroy(collision.gameObject);
        } 
    }
}
