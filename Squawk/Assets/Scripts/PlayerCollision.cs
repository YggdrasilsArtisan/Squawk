using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public AudioClip hitClip;
    private AudioSource robinAudioSource;
    private bool playHitSound = false;

    void Start()
    {
        robinAudioSource = GetComponent<AudioSource>();
    }

    //Method for playing Robin-Hit.wav
    public void PlayHitSoundEffect()
    {
        robinAudioSource.clip = hitClip;
        robinAudioSource.PlayOneShot(hitClip);
    }

    void Update()
    {
        //Check if sound effect needs to be played
        if (playHitSound == true)
        {
            robinAudioSource.Play();
        }
        else if (playHitSound == false)
        {
            robinAudioSource.Stop();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.tag == "Obstacle")
        {
            PlayHitSoundEffect();
            playHitSound = true;
            SceneManager.LoadScene(3, LoadSceneMode.Single); //Loads the fourth Scene (Game Over) in Build Settings
        }
    }

}
