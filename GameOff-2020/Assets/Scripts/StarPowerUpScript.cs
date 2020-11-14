using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPowerUpScript : MonoBehaviour
{
    public ParticleSystem Effect;
    public int EffectAmount = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("star hit");
            Effect.Emit(EffectAmount);
            Destroy(gameObject);
            //Destroy(Effect, 2f);
        } 
    }
}
