using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    //Variables for player controls
    public float speed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        playerDirection = new Vector2(0, directionY).normalized;
    }

  
    public void FixedUpdate()
    {
        //Controls player movement speeds
        rb.velocity = new Vector2(0, playerDirection.y * speed);
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
}
