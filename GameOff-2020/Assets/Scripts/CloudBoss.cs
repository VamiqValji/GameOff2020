using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBoss : MonoBehaviour
{
    public Transform player;
    public float Distance = 10f;
    private Vector2 respawnPoint;
    public float speed = 10f;

    private float Timer;
    public int WaitingTime = 3;

    Vector3 start;
    Vector3 end;

    public GameObject Lightning;

    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > 100 && player.transform.position.y < 190)
        {
            // MOVE TO PLAYER
            start = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            end = new Vector3(player.position.x, player.position.y + Distance, transform.position.z);
            transform.position = Vector3.Lerp( start, end , speed * Time.deltaTime);

            // ATTACK TIMER
            Timer += Time.deltaTime;
            if (Timer > WaitingTime)
            {
                Attack();
                Timer = 0;
            }
        }
    }
    private void Attack()
    {
        Instantiate(Lightning, transform.position, transform.rotation);
    }
}
