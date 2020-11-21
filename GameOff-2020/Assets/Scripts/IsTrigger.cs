using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTrigger : MonoBehaviour
{
    public Collider collider;
    public Transform player;
    public GameObject cloudDeath;
    public GameObject demonDeath;
    public GameObject unicornDeath;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
        collider.isTrigger = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (collider.isTrigger == true)
        //{
        //    if (player.transform.position.y < 180)
        //    {
        //        Instantiate(cloudDeath, transform.position, cloudDeath.transform.rotation);
        //    }
        //    else
        //    {
        //        if (player.transform.position.y > 180)
        //        {
        //            Instantiate(demonDeath, transform.position, demonDeath.transform.rotation);
        //        }
        //        else
        //        {
        //            if (player.transform.position.y > 360)
        //            {
        //                Instantiate(unicornDeath, transform.position, demonDeath.transform.rotation);
        //            }
        //        }
        //    }
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player.transform.position.y < 180)
        {
            Instantiate(cloudDeath, transform.position, cloudDeath.transform.rotation);
        }
        else
        {
            if (player.transform.position.y > 180)
            {
                Instantiate(demonDeath, transform.position, demonDeath.transform.rotation);
            }
            else
            {
                if (player.transform.position.y > 360)
                {
                    Instantiate(unicornDeath, transform.position, demonDeath.transform.rotation);
                }
            }
        }
    }

    public void Triggered()
    {
        collider.isTrigger = true;
    }
    public void Untriggered()
    {
        collider.isTrigger = false;
    }
}