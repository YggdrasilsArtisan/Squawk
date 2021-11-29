using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    //Variables for player controls
    public float speed;
    public Rigidbody2D rb;
    Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        //Gets player input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }


    //Triggers when player collects a seed. Despawns seed and adds point to score
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            Destroy(collision.gameObject);

            ScoreManager.instance.AddPoint();
        }
    }

  
    public void FixedUpdate()
    {
        //Controls player movement speeds
        movement.Normalize();
        rb.velocity = new Vector2(movement.x * speed * Time.fixedDeltaTime, movement.y * speed * Time.fixedDeltaTime);
    }
}
