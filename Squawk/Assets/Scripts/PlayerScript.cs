using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    //Variables for player controls
    public float speed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;
    private AudioSource sound;
    public AudioClip collectibleClip;
    public AudioClip powerUpClip;
    private bool playedSound = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sound = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        playerDirection = new Vector2(0, directionY).normalized;

        //Check if sound was played
        if (playedSound == true)
        {
            playedSound = false;
        }
        else if (playedSound == false)
        {
            sound.Stop();
        }
        
    }


    public void FixedUpdate()
    {
        //Controls player movement speeds
        rb.velocity = new Vector2(0, playerDirection.y * speed);
    }

    public void PlayCollectibleSoundEffect()
    {
        sound.clip = collectibleClip;
        sound.PlayOneShot(collectibleClip);
    }

    public void PlayPowerUpSoundEffect()
    {
        sound.clip = powerUpClip;
        sound.PlayOneShot(powerUpClip);
    }


    //Triggers when player collects a collectable. Despawns collectable and does desired effect
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Seed"))
        {
            PlayCollectibleSoundEffect();    
            Destroy(collision.gameObject);
            playedSound = true;

            ScoreManager.instance.AddPoint();
        }

       if (collision.CompareTag("Speedberry"))
        {
            PlayPowerUpSoundEffect();
            Destroy(collision.gameObject);
            playedSound = true;
        }

        if (collision.CompareTag("Invinciberry"))
        {
            PlayPowerUpSoundEffect(); 
            Destroy(collision.gameObject);
            playedSound = true;
        }

        if (collision.CompareTag("Feather"))
        {
            PlayCollectibleSoundEffect();
            Destroy(collision.gameObject);
            playedSound = true;

            StaminaBar.instance.regenStamina();

        }
    }

}
