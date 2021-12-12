using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script to control the owl's animations
public class OwlAttack : MonoBehaviour
{

    //variables for speed control
    public float speedY = 13;
    public int speedX = 13;
    private Rigidbody2D rb;
    private Vector2 direction;

    //variables for controlling attack
    bool canAttack = true;

    //Variables for controlling sound
    private AudioSource owlAudioSource;
    public AudioClip owlAttackClip;

    Animator owlAnimator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        owlAudioSource = GetComponent<AudioSource>();
        owlAnimator = GetComponent<Animator>();

        //Ignore Obstacles collision
        Physics2D.IgnoreLayerCollision(7, 7, true);
    }


    private void Update()
    {

    }

    //Method for adjusting pitch of and playing Hawk-Screeching.wav
    public void AdjustAndPlayAttackSoundEffect() 
    {
        owlAudioSource.clip = owlAttackClip;
        owlAudioSource.pitch = 1.50f;
        owlAudioSource.PlayOneShot(owlAttackClip);
    }
    void FixedUpdate()
    {

       rb.velocity = new Vector2(speedX, speedY);

        //RNG determines when Hawk should attack
        int randNum = Random.Range(0, 100); //Random number between 1 and 500. Determines how often owl attacks

        if (randNum == 2)
        {
            if (canAttack == true)
                StartCoroutine("Attack");
        }
    }

    IEnumerator Attack()
    {
        int ranNum = Random.Range(0, 4);

        AdjustAndPlayAttackSoundEffect();
        canAttack = false;
        yield return new WaitForSeconds(2f); //Gives player 2 seconds to move out of the owl's path
        speedX = -9;
        if (ranNum == 1)
            speedY =  0;
        if (ranNum == 2)
            speedY = -3;
        if (ranNum == 3)
            speedY = -6;
        yield return new WaitForSeconds(.5f);
        owlAnimator.SetTrigger("Attack");
        yield return new WaitForSeconds(.9f);
        owlAnimator.SetTrigger("Fly");
        speedX = 9;
        if (ranNum == 1)
            speedY = 0;
        if (ranNum == 2)
            speedY = 3;
        if (ranNum == 3)
            speedY = 6;
        yield return new WaitForSeconds(1.4f);
        speedX = 0;
        speedY = 0;
        canAttack = true;

    }
}