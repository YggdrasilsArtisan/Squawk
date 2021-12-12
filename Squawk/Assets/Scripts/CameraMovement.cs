using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Joshua's script for controlling camera movement in the game's main level
//Used in final build
public class CameraMovement : MonoBehaviour
{
    public static CameraMovement instance;

    public float cameraSpeed;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
    }
}
