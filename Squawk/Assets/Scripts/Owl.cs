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
        //GetComponents for animation
        owlAnimator = GetComponent<Animator>();
        owlRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (owlRigidbody.position.x == GameObject.Find("Robin").transform.position.x)
        {
            owlAnimator.SetTrigger("Attack");
        }
    }
}