using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    public List<AudioClip> soundEffects;

    public void playEffect (int number)
    {
        GetComponent<AudioSource>().clip = soundEffects[number];
        GetComponent<AudioSource>().Play();
    }
}
