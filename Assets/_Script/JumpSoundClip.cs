///By Jing Yuan Cheng 101257237
/// JumpSound Script
/// 
/// Version 1.0
/// Last edited on Dec 11 2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSoundClip : MonoBehaviour
{
    public List<AudioClip> JumpSoundClips;

    public AudioSource soundSource;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayJumpSound()
    {
        soundSource.clip = JumpSoundClips[0];
        soundSource.Play();
    }
}
