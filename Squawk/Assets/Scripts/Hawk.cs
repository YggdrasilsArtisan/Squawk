using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hawk : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    private Vector2 playerDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(7, 7, true);
        Physics2D.IgnoreLayerCollision(7, 8, true);
    }


    private void Update()
    {
        playerDirection = new Vector2(0, 0).normalized;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, playerDirection.y * speed);

    }
}
