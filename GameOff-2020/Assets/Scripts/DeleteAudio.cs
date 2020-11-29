using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAudio : MonoBehaviour
{
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (audioSource.isPlaying == false)
        {
            //Debug.Log(audioSource + " destroyed.");
            Destroy(gameObject);
        }
    }
}
