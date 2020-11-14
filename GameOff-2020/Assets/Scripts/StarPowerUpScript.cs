using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPowerUpScript : MonoBehaviour
{
    public GameObject Effect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("star hit");
            Instantiate(Effect, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(Effect, 2f);
        } 
    }
}
