using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance;

    //Variables for player controls
    public float speed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;
    private AudioSource robinCollectAudioSource;
    public AudioClip collectibleClip;
    public AudioClip powerUpClip;
    private bool playSound = false;

    public bool speedActive = false;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        robinCollectAudioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        playerDirection = new Vector2(0, directionY).normalized;

        //Check if sound was played
        if (playSound == true)
        {
            robinCollectAudioSource.Play();
            playSound = false;
        }
        else if (playSound == false)
        {
            robinCollectAudioSource.Stop();
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
        robinCollectAudioSource.clip = collectibleClip;
        robinCollectAudioSource.PlayOneShot(collectibleClip);
        Debug.Log("Got a collectible chirp");
    }

    //Method for playing Power-Item.wav
    public void PlayPowerUpSoundEffect()
    {
        robinCollectAudioSource.clip = powerUpClip;
        robinCollectAudioSource.PlayOneShot(powerUpClip);
        Debug.Log("Got a power-up chirp");
    }


    //Triggers when player collects a collectable. Despawns collectable and does desired effect
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Seed"))
        {
            PlayCollectibleSoundEffect();
            playSound = true;
            Destroy(collision.gameObject);

            ScoreManager.instance.AddPoint();
        }

       if (collision.CompareTag("Speedberry"))
        {
            PlayPowerUpSoundEffect();
            playSound = true;
            Destroy(collision.gameObject);

            StartCoroutine("GetSpeed");
        }

        if (collision.CompareTag("Invinciberry"))
        {
            PlayPowerUpSoundEffect();
            playSound = true;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Feather"))
        {
            PlayCollectibleSoundEffect();
            playSound = true;
            Destroy(collision.gameObject);

            StaminaBar.instance.regenStamina();

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

    public bool getSpeedActive()
    {
        return speedActive;
    }
}
