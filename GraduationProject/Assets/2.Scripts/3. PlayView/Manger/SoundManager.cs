using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bkAudio;
    public GameObject dontDestroy;

    [Header("Clip")]
    public AudioClip button;
    public AudioClip drag;
    public AudioClip zombi;

    private void Start()
    {
        DontDestroyOnLoad(dontDestroy);

        GameObject[] audios = GameObject.FindGameObjectsWithTag("BackGroundMusic");

        if (audios.Length >= 2)
        {
            Destroy(audios[1]);
        }
    }
}
