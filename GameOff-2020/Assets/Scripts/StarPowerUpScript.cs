using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPowerUpScript : MonoBehaviour
{
    public EffectsPostProcessing PostProcessingScript;
    public RocketController PlayerScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            PostProcessingScript.StarPowerUp();
            PlayerScript.StarPowerUp();
        }
    }
}
