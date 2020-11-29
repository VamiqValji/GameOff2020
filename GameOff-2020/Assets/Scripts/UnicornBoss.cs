using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnicornBoss : MonoBehaviour
{
    private Transform player;
    public float Distance = 10f;
    public float speed = 1f;

    private float Timer;
    private float defaultTimer;
    public int WaitingTime = 3;

    private bool smoothFollow = true;

    Vector3 start;
    Vector3 end;

    public GameObject RightAttack;
    public GameObject LeftAttack;
    public GameObject MiddleAttack;

    //public ParticleSystem Middle;
    //public ParticleSystem Right;
    //public ParticleSystem Left;

    public GameObject OnDeath;

    public GameObject DeathSound;

    private bool Death = false;

    private Vector2 respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        defaultTimer = Timer;
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > 430 && player.transform.position.y < 500)
        {
            Debug.Log(smoothFollow);
            // MOVE TO PLAYER
            start = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            end = new Vector3(player.position.x, player.position.y + Distance, transform.position.z);
            if (smoothFollow == true)
            {
                transform.position = Vector3.Lerp(start, end, speed * Time.deltaTime);
                //Middle.Emit(1);
            }
            else
            {
                transform.position = Vector3.Lerp(start, end, (speed / 2f) * Time.deltaTime);
                //Right.Emit(1);
                //Left.Emit(1);
            }

            // ATTACK TIMER
            Timer += Time.deltaTime;
            if (Timer > WaitingTime)
            {

                if (player.transform.position.y > 450)
                {
                    Timer = Timer * 1/3;
                }
                else
                {
                    Timer = defaultTimer;
                }

                if (smoothFollow == true)
                {
                    Attack();
                    smoothFollow = false;
                }
                else
                {
                    FollowAttack();
                    smoothFollow = true;
                }

                Timer = 0;
            }
        }

        if (player.transform.position.y > 495)
        {
            if (Death == false)
            {
                Instantiate(OnDeath, transform.position, transform.rotation); // Particles
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
        var randNum = Random.Range(1,3);
        if (randNum == 1)
        {
            Instantiate(RightAttack, new Vector2(-7, player.transform.position.y + 5f), RightAttack.transform.rotation);
        }
        else
        {
            Instantiate(LeftAttack, new Vector2(7, player.transform.position.y - 5f), LeftAttack.transform.rotation);
        }
    }
    private void FollowAttack()
    {
        Instantiate(MiddleAttack, new Vector2(transform.position.x, transform.position.y - 1f), MiddleAttack.transform.rotation);
    }
}
