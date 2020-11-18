using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonBoss : MonoBehaviour
{
    public Transform player;
    public float Distance = 10f;
    public float speed = 1f;

    private float Timer;
    public int WaitingTime = 3;

    private bool smoothFollow = true;

    Vector3 start;
    Vector3 end;

    public GameObject FireballAttack;

    // Start is called before the first frame update
    void Start()
    {

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
            }
            else
            {
                transform.position = Vector3.Lerp(start, end, (speed / 2f) * Time.deltaTime);
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
    }
    private void Attack()
    {
        Instantiate(FireballAttack, transform.position, FireballAttack.transform.rotation);
    }
    private void AttackArms()
    {
        Instantiate(FireballAttack, new Vector2 (transform.position.x + 3f, transform.position.y - 3f), FireballAttack.transform.rotation);
        Instantiate(FireballAttack, new Vector2(transform.position.x - 3f, transform.position.y - 3f), FireballAttack.transform.rotation);
    }
}
