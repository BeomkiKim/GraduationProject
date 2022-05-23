using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    AudioSource audioSource;
    private Animator playerAnimator;


    public AudioClip audioSword;


    private void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();


    }

    public void PlaySword()
    {
        audioSource.clip = audioSword;
        audioSource.Play();
        Clear();
    }

    IEnumerator Clear()
    {
        yield return new WaitForSeconds(0.3f);
        audioSource.clip = null;
    }
}
