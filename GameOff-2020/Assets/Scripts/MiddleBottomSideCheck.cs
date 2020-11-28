using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleBottomSideCheck : MonoBehaviour
{
    private float highscore; // For this level
    private float score;
    public float distance = 10f;
    public Transform player;
    public Transform bottomSideCheck;
    public Vector3 respawnPoint;
    public Transform particleObject;
    //public ParticleSystem Particles;
    public float particlesAboveSpeed = 20f;
    public Animator BIncomingAnimator;
    private bool entry = true;
    public GameObject BossIncomingSound;

    // Start is called before the first frame update
    void Start()
    {
        highscore = 0;
        score = 0;
        respawnPoint = new Vector3(8, player.position.y - distance, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        particleObject.transform.position = Vector2.Lerp(new Vector2(particleObject.transform.position.x, particleObject.transform.position.y) , new Vector2(player.position.x, player.position.y + distance + 2f), particlesAboveSpeed);
        score = player.position.y;
        if (score < 0)
        {
            score = 0;
            highscore = 0;
            bottomSideCheck.position = respawnPoint;
            entry = true;
            BossIncomingSound.SetActive(false);
            BIncomingAnimator.SetTrigger("HardReset");
        }
        if (score > highscore)
        {
            highscore = score;
            //Debug.Log(new Vector3(bottomSideCheck.position.x, bottomSideCheck.position.y - distance, bottomSideCheck.position.z));
            bottomSideCheck.localPosition = new Vector3(8, player.position.y - distance, 0);
        }

        if (score > 87 && score < 90 && entry == true) // Cloud Boss
        {
            SetAnim();
        }
        if (score > 87 + 30 && entry == false)
        {
            ResetAnim();
        }

        if (score > 267 && score < 270 && entry == true) // Demon Boss
        {
            SetAnim();
        }
        if (score > 267 + 30 && entry == false)
        {
            ResetAnim();
        }

        if (score > 417 && score < 420 && entry == true) // Unicorn Boss
        {
            SetAnim();
        }
        if (score > 417 + 30 && entry == false)
        {
            ResetAnim();
        }

    }

    private void SetAnim()
    {
        entry = false;
        BIncomingAnimator.SetTrigger("FadeIn");
        //Instantiate(BossIncomingSound,transform.position,transform.rotation);
        BossIncomingSound.SetActive(true);
    }

    private void ResetAnim()
    {
        entry = true;
        BIncomingAnimator.ResetTrigger("FadeIn");
        BossIncomingSound.SetActive(false);
    }
}
