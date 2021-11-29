using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for controlling camera movement in the game's main level
public class Level : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPosition = Camera.main.transform.position;
        cameraPosition.x += 0.01f;
        Camera.main.transform.position = cameraPosition;

        if (cameraPosition.x >= 563.9621f)
        {
            cameraPosition.x = 377.78f;
            Camera.main.transform.position = cameraPosition;
        }
    }
}
