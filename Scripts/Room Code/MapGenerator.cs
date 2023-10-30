using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] gridPrefabs;
    public int rows;
    public int cols;
    public float roomWidth = 50.0f;
    public float roomHeight = 50.0f;
    public KeyCode CallGenerateMap;
    public int mapSeed;
    public bool isMapOfTheDay;
    public bool isRandomMap;

    private Room[,] grid;

    // Start is called before the first frame update
    void Start()
    {
        if (isMapOfTheDay)
        {
            mapSeed = DateToInt(DateTime.Now.Date);
        }
        else if (isRandomMap)
        {
            mapSeed = DateToInt(DateTime.Now);
        }

        UnityEngine.Random.InitState(mapSeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(CallGenerateMap))
        {
            GenerateMap();
        }
    }

    public int DateToInt(DateTime dateToUse)
    {
        // Add our date up and return it
        return dateToUse.Year + dateToUse.Month + dateToUse.Day + dateToUse.Hour + dateToUse.Minute + dateToUse.Second + dateToUse.Millisecond;
    }

    public GameObject RandomRoomPrefab()
    {
        return gridPrefabs[UnityEngine.Random.Range(0, gridPrefabs.Length)];
    }

    public void GenerateMap()
    {
        grid = new Room[cols, rows];

        for (int currentRow = 0; currentRow < rows; currentRow++)
        {
            for (int currentCol = 0; currentCol < cols; currentCol++)
            {
                float xPosition = roomWidth * currentCol;
                float zPosition = roomHeight * currentRow;
                Vector3 newPosition = new Vector3(xPosition, 0.0f, zPosition);

                GameObject tempRoomObj = Instantiate(RandomRoomPrefab(), newPosition, Quaternion.identity) as GameObject;

                tempRoomObj.transform.parent = this.transform;

                tempRoomObj.name = "Room_" + currentCol + "," + currentRow;

                Room tempRoom = tempRoomObj.GetComponent<Room>();

                grid[currentCol, currentRow] = tempRoom;


                if (currentRow == 0)
                {
                    tempRoom.doorNorth.SetActive(false);
                }
                else if (currentRow == rows - 1)
                {
                    Destroy(tempRoom.doorSouth);
                }
                else
                {
                    Destroy(tempRoom.doorNorth);
                    Destroy(tempRoom.doorSouth);
                }

                if (currentCol == 0)
                {
                    tempRoom.doorEast.SetActive(false);
                }
                else if (currentCol == cols - 1)
                {
                    Destroy(tempRoom.doorWest);
                }
                else
                {
                    Destroy(tempRoom.doorEast);
                    Destroy(tempRoom.doorWest);
                }
            }
        }
    }


}
