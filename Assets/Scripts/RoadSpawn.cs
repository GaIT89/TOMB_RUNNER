using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoadSpawn : MonoBehaviour
{
    public GameObject RoadToSpawn; 
    public Transform playerTransform;

    private List<GameObject> listOfRoadWasSpawn;

    ///private float saveZone = 550f;
    private float zPosToSpawn = -20f;
    private float roadLength = 550f;
    private int numberRoadOnScene = 3;

    void Start()
    {
        listOfRoadWasSpawn = new List<GameObject>();
        for (int road = 0; road < numberRoadOnScene; road++)
        {
            SpawnRoad();
        }
    }

    void Update()
    {
        if (playerTransform.position.z - roadLength > (zPosToSpawn - (numberRoadOnScene * roadLength)))
        {
            SpawnRoad();
            RemoveRoad();
        }
    }
    private void RemoveRoad()
    {
        Destroy(listOfRoadWasSpawn[0]);
        listOfRoadWasSpawn.RemoveAt(0);
    }

    void SpawnRoad()
    {
        GameObject road;
        road = Instantiate(RoadToSpawn);
        road.transform.SetParent(transform);
        road.transform.position = Vector3.forward * zPosToSpawn;
        zPosToSpawn += roadLength;
        listOfRoadWasSpawn.Add(road);
    }
}
