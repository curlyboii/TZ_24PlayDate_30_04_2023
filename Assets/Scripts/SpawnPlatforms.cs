using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatforms : MonoBehaviour
{
    public GameObject[] spawnerPlatform; //new platform
    public Transform lastPlatform;
    Vector3 lastPosition;
    Vector3 newPosition;
    bool stop;


    // Start is called before the first frame update
    void Start()
    {
        lastPosition = lastPlatform.position;
        StartCoroutine(SpawnPlatform());
    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator SpawnPlatform()
    {

        while (!stop)
        {
            Position();
            int randomIndex = Random.Range(0, spawnerPlatform.Length);
            GameObject platformPrefab = spawnerPlatform[randomIndex];
            Instantiate(platformPrefab, newPosition, Quaternion.identity);
            lastPosition = newPosition;
            yield return new WaitForSeconds(1f);
        }


    }



    void Position()
    {
        newPosition = lastPosition;
        newPosition.z += 40f;

    }
}
