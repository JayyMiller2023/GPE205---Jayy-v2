using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject pickupPrefab;
    public Pawn owner;
    public float spawnDelay;

    private float nextSpawnTime;
    private Transform tf;
    private GameObject spawnedPickup;

    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = Time.time + spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {

        if (spawnedPickup == null)
        {
            if (Time.time > nextSpawnTime)
            {
                spawnedPickup = Instantiate(pickupPrefab, transform.position, Quaternion.identity) as GameObject;
                nextSpawnTime = Time.time + spawnDelay;
            }
        }
        else
        {
            nextSpawnTime = Time.time + spawnDelay;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        //Getting Health component
        Powerup ex = other.gameObject.GetComponent<Powerup>();
        //if it has a health component...
        if (ex != null)
        {
            Destroy(pickupPrefab);
        }

    }
}
