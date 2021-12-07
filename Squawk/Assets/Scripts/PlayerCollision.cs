using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public AudioClip hitClip;
    private AudioSource sound;
    private bool playedSound = false;

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }
    public void PlayHitSoundEffect()
    {
        sound.clip = hitClip;
        sound.PlayOneShot(hitClip);
    }

    void Update()
    {
        if (playedSound == true)
        {
            sound.Play();
        }
        else if (playedSound == false)
        {
            sound.Stop();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.tag == "Obstacle")
        {
            PlayHitSoundEffect();
            playedSound = true;
            SceneManager.LoadScene(3, LoadSceneMode.Single); //Loads the fourth Scene (Game Over) in Build Settings
        }
    }

}
