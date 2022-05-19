using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip healthSound, hitSound, jumpSound, pistolSound, rocketSound, deathSound;
    static AudioSource audioSrc;

    void Start()
    {
        healthSound = Resources.Load<AudioClip>("Health");
        hitSound = Resources.Load<AudioClip>("Hit");
        jumpSound = Resources.Load<AudioClip>("Jump");
        pistolSound = Resources.Load<AudioClip>("Pistol");
        rocketSound = Resources.Load<AudioClip>("Rocket");
        deathSound = Resources.Load<AudioClip>("Death");

        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "health":
                audioSrc.PlayOneShot(healthSound);
                break;
            case "hit":
                audioSrc.PlayOneShot(hitSound);
                break;
            case "jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "pistol":
                audioSrc.PlayOneShot(pistolSound);
                break;
            case "rocket":
                audioSrc.PlayOneShot(rocketSound);
                break;
            case "death":
                audioSrc.PlayOneShot(deathSound);
                break;
        }
    }
}