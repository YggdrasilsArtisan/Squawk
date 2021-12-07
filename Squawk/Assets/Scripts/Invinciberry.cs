using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invinciberry : MonoBehaviour
{

    Renderer rend;
    Color c;

    //Sets up componants that allow for transparancy effect
    void Start()
    {
        rend = GetComponent<Renderer>();
        c = rend.material.color;
    }

   //Triggers "GetInvincible" method if player hits Invinciberry
   void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Invinciberry"))
            StartCoroutine("GetInvincible");
    }

    //Makes player invincible and transparent
    IEnumerator GetInvincible()
    {
        Physics2D.IgnoreLayerCollision(0, 7, true);
        c.a = 0.35f; 
        rend.material.color = c;
        yield return new WaitForSeconds(10f); //Sets how long effect lasts for
        Physics2D.IgnoreLayerCollision(0, 7, false);
        c.a = 1f;
        rend.material.color = c;
    }



}
