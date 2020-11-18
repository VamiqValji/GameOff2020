using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonDeathParticles : MonoBehaviour
{
    private float Timer;
    public float WaitingTime = 1.5f;
    public ParticleSystem OnDeath;
    public int Emission = 50;

    void Start()
    {
        OnDeath.Emit(Emission);
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
