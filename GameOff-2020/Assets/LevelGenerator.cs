using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public GameObject Level;
    public Transform player;

    private GameObject[] LevelList;

    private float count;

    //public Transform levelStart;
    //public Transform levelEnd;

    // LEVEL LENGTH IS 108.15591 \\
    // START POINT: -17.05591
    // END POINT: 91.1

    // Start is called before the first frame update
    void Start()
    {
        count = 0f;
        //Debug.Log(Level.transform.position.y); // 656.6959
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.transform.position.y > 490 + (count * 108.15591f))
        {
            if (count < 1)
            {
                Instantiate(Level, new Vector2(14.02219f, 656.6959f + (count * 108.15591f)), Level.transform.rotation);
            }
            else
            {
                Instantiate(Level, new Vector2(14.02219f, 656.6959f + (count * 108.1f)), Level.transform.rotation);
            }
            count += 1f;
        }

        // RESET
        if (player.transform.position.y < 5)
        {
            count = 0f;

            Enemy = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject Enemies in Enemy)
            {
                Destroy(Enemies);
            }

        }
    }
}
