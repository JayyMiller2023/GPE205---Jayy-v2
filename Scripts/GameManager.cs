using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public Transform playerSpawnTransform;

    // Prefabs
    public GameObject playerControllerPrefab;
    public GameObject tankPawnPrefab;

    public List<PlayerController> player;

    private void Start()
    {
        //Temp SpawnCode
        SpawnPlayer();
    }


    // Can be called before Start!
    private void Awake()
    {
        if (Instance == null)
        {
            //Instance is this script
            Instance = this;
            //Do not Destroy this when loading a new level
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SpawnPlayer()
    {
        //Spawn at Origin with no rotation
        GameObject newPlayerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        //Spawn pawn and connect to Controller
        GameObject newPawnObj = Instantiate(tankPawnPrefab, playerSpawnTransform.position, playerSpawnTransform.rotation) as GameObject;

        //Get the Player Controller and Pawn Component
        Controller newController = newPlayerObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        //Hooking them together!
        newController.pawn = newPawn;

    }
}
