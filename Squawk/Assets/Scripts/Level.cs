using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for controlling camera movement in the game's main level
public class Level : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPosition = Camera.main.transform.position; //Stores the position of Main Camera
        cameraPosition.x += 0.01f; //Add 0.01 to position on x-axis
        Camera.main.transform.position = cameraPosition; //Moves Main Camera

        //Moves camera back to starting position after reaching end of background art
        if (cameraPosition.x >= 563.9621f)
        {
            cameraPosition.x = 377.78f;
            Camera.main.transform.position = cameraPosition;
        }
    }
}
