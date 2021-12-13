using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance;

    //Variables for player controls
    public float speed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;
    private AudioSource robinAudioSource;
    public AudioClip collectibleClip;
    public AudioClip powerUpClip;
    public AudioClip hitClip;
    private bool playSound = false;

    public bool speedActive = false;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60; //Sets the game's frame rate
        rb = GetComponent<Rigidbody2D>();
        robinAudioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        playerDirection = new Vector2(0, directionY).normalized;

        if (playSound == false)
        {
            robinAudioSource.Stop();
        }

    }


    public void FixedUpdate()
    {
        //Controls player movement speeds
        rb.velocity = new Vector2(0, playerDirection.y * speed);
    }

    //Method for playing Got-Collectable.wav
    public void PlayCollectibleSoundEffect()
    {
        robinAudioSource.clip = collectibleClip;
        robinAudioSource.PlayOneShot(collectibleClip);
        robinAudioSource.Play();
    }

    //Method for playing Power-Item.wav
    public void PlayPowerUpSoundEffect()
    {
        robinAudioSource.clip = powerUpClip;
        robinAudioSource.PlayOneShot(powerUpClip);
        robinAudioSource.Play();
    }

    //Method for playing Robin-Hit.wav
    public void PlayHitSoundEffect()
    {
        robinAudioSource.clip = hitClip;
        robinAudioSource.PlayOneShot(hitClip);
        robinAudioSource.Play();
    }


    //Plays sound and other effects when player hits collectible
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Seed"))
        {
            playSound = true;
            PlayCollectibleSoundEffect();

            ScoreManager.instance.AddPoint();
        }

       if (collision.CompareTag("Speedberry"))
        {
            playSound = true;
            PlayPowerUpSoundEffect();

            StartCoroutine("GetSpeed");
        }

        if (collision.CompareTag("Invinciberry"))
        {
            playSound = true;
            PlayPowerUpSoundEffect();
        }

        if (collision.CompareTag("Feather"))
        {
            playSound = true;
            PlayCollectibleSoundEffect();

            StaminaBar.instance.regenStamina();

        }
    }

    //Despawns collectibles and stops sounds
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Seed"))
        {
            playSound = false;
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Feather"))
        {
            playSound = false;
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Speedberry"))
        {
            playSound = false;
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Invinciberry"))
        {
            playSound = false;
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.CompareTag("Obstacle"))
        {
            playSound = true;
            PlayHitSoundEffect();
            SceneManager.LoadScene(3, LoadSceneMode.Single); //Loads the fourth Scene (Game Over) in Build Settings
        }
    }

    IEnumerator GetSpeed()
    {
        speed = 22;
        speedActive = true;
        yield return new WaitForSeconds(10f); //Sets how long effect lasts for
        speed = 12;
        speedActive = false;
    }

    public bool GetSpeedActive()
    {
        return speedActive;
    }
}
