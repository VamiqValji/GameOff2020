using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPowerUpScript : MonoBehaviour
{
    public GameObject Effect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(gameObject);
        Debug.Log("star hit");
        Instantiate(Effect, transform.position, transform.rotation);
    }
}
