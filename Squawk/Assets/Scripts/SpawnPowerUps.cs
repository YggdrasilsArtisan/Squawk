using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUps : MonoBehaviour
{
    public GameObject collectable;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    bool canSpawn = true;

    // Update is called once per frame
    void Update()
    {
        int ranNum = Random.Range(0, 15000);

        if (ranNum == 2 && canSpawn == true)
        {
            Spawn();
            canSpawn = false;
            StartCoroutine("wait");
        }
    }

    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(collectable, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(15f);
        canSpawn = true;
    }
}