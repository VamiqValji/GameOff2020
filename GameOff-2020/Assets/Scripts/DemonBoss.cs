using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonBoss : MonoBehaviour
{
    private Transform player;
    public float Distance = 10f;
    public float speed = 1f;

    private float Timer;
    public int WaitingTime = 3;

    private bool smoothFollow = true;

    Vector3 start;
    Vector3 end;

    public GameObject FireballAttack;

    public ParticleSystem Middle;
    public ParticleSystem Right;
    public ParticleSystem Left;

    public GameObject OnDeath;

    public GameObject DeathSound;

    private bool Death = false;

    private Vector2 respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > 290 && player.transform.position.y < 350)
        {
            Debug.Log(smoothFollow);
            // MOVE TO PLAYER
            start = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            end = new Vector3(player.position.x, player.position.y + Distance, transform.position.z);
            if (smoothFollow == true)
            {
                transform.position = Vector3.Lerp(start, end, speed * Time.deltaTime);
                Middle.Emit(1);
            }
            else
            {
                transform.position = Vector3.Lerp(start, end, (speed / 2f) * Time.deltaTime);
                Right.Emit(1);
                Left.Emit(1);
            }

            // ATTACK TIMER
            Timer += Time.deltaTime;
            if (Timer > WaitingTime)
            {
                if (smoothFollow == true)
                {
                    Attack();
                    smoothFollow = false;
                }
                else
                {
                    AttackArms();
                    smoothFollow = true;
                }

                Timer = 0;
            }
        }

        if (player.transform.position.y > 345)
        {
            if (Death == false)
            {
                Instantiate(OnDeath, transform.position, transform.rotation);
                Instantiate(DeathSound, transform.position, transform.rotation); // Death Sound
                Destroy(gameObject);
                Death = true;
            }
        }

        if (player.transform.position.y < 0)
        {
            transform.position = respawnPoint;
        }
    }
    private void Attack()
    {
        Instantiate(FireballAttack, new Vector2(transform.position.x, transform.position.y - 1f), FireballAttack.transform.rotation);
    }
    private void AttackArms()
    {
        Instantiate(FireballAttack, new Vector2 (transform.position.x + 2f, transform.position.y - 2.5f), FireballAttack.transform.rotation);
        Instantiate(FireballAttack, new Vector2(transform.position.x - 2f, transform.position.y - 2.5f), FireballAttack.transform.rotation);
    }
}
