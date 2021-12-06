using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.transform.tag == "Obstacle")
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
    }
}
