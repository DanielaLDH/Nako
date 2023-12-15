using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    private AudioSource audiosource;

    public AudioClip collSound;


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
