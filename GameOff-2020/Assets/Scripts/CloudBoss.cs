using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBoss : MonoBehaviour
{
    public Transform player;
    public float Distance = 10f;
    //private bool Active = false;
    private Vector3 respawnPoint;

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
            Debug.Log(transform.position);
            transform.position = new Vector3( Mathf.Lerp(transform.position.x, player.position.x, 5f), Mathf.Lerp(transform.position.y, player.position.y + Distance, 5f), 0);
        }
    }
}
