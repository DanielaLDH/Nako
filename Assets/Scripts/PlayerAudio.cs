using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    private AudioSource audiosource;

   // public AudioClip hitSound;
    public AudioClip dmgSound;
    public AudioClip attackSound;
    public AudioClip healthPickSound;

    // Start is called before the first frame update
    void Start()
    {
       audiosource = GetComponent<AudioSource>();    
    }

    public void PlaySFX(AudioClip sfx)
    {
        Debug.Log(sfx);
        audiosource.PlayOneShot(sfx);
    }

}
