using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hawk : MonoBehaviour
{

    //variables for speed control
    public float speed;
    private Rigidbody2D rb;
    private Vector2 direction;

    //variables for controlling attack
    bool canMove = true;
    bool canAttack = true;
    bool canChangeDir = true;
    int speedX = 0;

    //Variables for controlling sound
    private AudioSource hawkAudioSource;
    public AudioClip attackClip;
 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hawkAudioSource = GetComponent<AudioSource>();

        //Ignore Obstacles collision
        Physics2D.IgnoreLayerCollision(7, 7, true);
    }


    private void Update()
    {
        if(canChangeDir == true)
            StartCoroutine("UpDown");
    }

    //Method for playing Hawk-Screeching.wav
    public void PlayAttackSoundEffect()
    {
        hawkAudioSource.clip = attackClip;
        hawkAudioSource.PlayOneShot(attackClip);
    }
    
    void FixedUpdate()
    {

        if (canMove == true)
            rb.velocity = new Vector2(speedX, direction.y * speed);
        else
            rb.velocity = new Vector2(speedX, 0);

        //RNG determines when Hawk should attack
        int randNum = Random.Range(0, 500); //Random number between 1 and 500. Determines how often hawk attacks

        if(randNum == 2)
        {
            if(canAttack == true)
                StartCoroutine("Attack");
        }
    }



    IEnumerator UpDown()
    {
        int randNum = Random.Range(0, 100);

        //Checks if hawk is attacking
        if (canMove == true)
        {
            //Determins if hawk needs to go up or down
            if (randNum >= 50)
            {
                canChangeDir = false;

                direction = new Vector2(0, -1).normalized;
                yield return new WaitForSeconds(1f);

                canChangeDir = true;
            }
            else
            {
                canChangeDir = false;

                direction = new Vector2(0, 1).normalized;
                yield return new WaitForSeconds(1f);

                canChangeDir = true;
            }
        }
        else
            direction = new Vector2(0, 0).normalized;
    }

   IEnumerator Attack()
   {
        PlayAttackSoundEffect();
        canMove = false;
        canAttack = false;
        yield return new WaitForSeconds(2f); //Gives player 2 seconds to move out of the hawk's path
        speedX = 10;
        yield return new WaitForSeconds(1f);
        speedX = -10;
        yield return new WaitForSeconds(1f);
        speedX = 0;
        canMove = true;
        yield return new WaitForSeconds(3f); //Keeps hawk from attacking again for 5 seconds
        canAttack = true;

   }
}
