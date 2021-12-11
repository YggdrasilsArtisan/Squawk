using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Allows borders to move with camera
public class Borders : MonoBehaviour
{
    public float speed = 12;
    private Rigidbody2D rb;

    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(0, 0).normalized;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, direction.y * speed);

    }
}
