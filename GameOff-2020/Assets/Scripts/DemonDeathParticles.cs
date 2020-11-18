using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonDeathParticles : MonoBehaviour
{
    private float Timer;
    public float WaitingTime = 1.5f;
    public ParticleSystem OnDeath;

    void Start()
    {
        OnDeath.Emit(50);
    }

    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > WaitingTime)
        {
            Destroy(gameObject);
        }
    }
}
