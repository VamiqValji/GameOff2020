using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnicornBoss : MonoBehaviour
{
    public Transform player;
    public float Distance = 10f;
    public float speed = 1f;

    private float Timer;
    public int WaitingTime = 3;

    private bool smoothFollow = true;

    Vector3 start;
    Vector3 end;

    public GameObject Attack;

    //public ParticleSystem Middle;
    //public ParticleSystem Right;
    //public ParticleSystem Left;

    public GameObject OnDeath;

    private bool Death = false;

    // Start is called before the first frame update
    void Start()
    {

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
                Destroy(gameObject);
                Death = true;
            }
        }
    }
    private void Attack()
    {
        Instantiate(Attack, new Vector2(transform.position.x, transform.position.y - 1f), FireballAttack.transform.rotation);
    }
    private void AttackArms()
    {
        Instantiate(Attack, new Vector2(transform.position.x + 2f, transform.position.y - 2.5f), FireballAttack.transform.rotation);
        Instantiate(Attack, new Vector2(transform.position.x - 2f, transform.position.y - 2.5f), FireballAttack.transform.rotation);
    }
}
