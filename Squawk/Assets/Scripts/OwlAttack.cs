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


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Ignore Obstacles collision
        Physics2D.IgnoreLayerCollision(7, 7, true);
    }


    private void Update()
    {

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
        int ranNum = Random.Range(0, 3);

        //Play audio queue
        canAttack = false;
        yield return new WaitForSeconds(3f); //Gives player 2 seconds to move out of the owl's path
        speedX = -6;
        if (ranNum == 1)
            speedY =  0;
        if (ranNum == 2)
            speedY = -3;
        if (ranNum == 3)
            speedY = -6;
        yield return new WaitForSeconds(2f);
        speedX = 6;
        if (ranNum == 1)
            speedY = 0;
        if (ranNum == 2)
            speedY = 3;
        if (ranNum == 3)
            speedY = 6;
        yield return new WaitForSeconds(2f);
        speedX = 0;
        speedY = 0;
        yield return new WaitForSeconds(3f); //Keeps owl from attacking again for 5 seconds
        canAttack = true;

    }
}