using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script to control the owl's animations
public class Owl : MonoBehaviour
{
    Animator owlAnimator;
    Rigidbody2D owlRigidbody;
 
 
    // Start is called before the first frame update
    void Start()
    {
        owlAnimator = GetComponent<Animator>();
        owlRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 owlPosition = owlRigidbody.transform.position;

        if (owlRigidbody.position.x == GameObject.Find("Robin").transform.position.x)
        {
            owlAnimator.SetTrigger("Attack");
            owlPosition.y -= 0.01f;
            owlRigidbody.transform.position = owlPosition;
        }
    }
}
