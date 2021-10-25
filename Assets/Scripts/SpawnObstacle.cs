using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public float intervalSpawn;
    public GameObject[] objectToSpawn;

    public Transform playerTransform;
    public Transform enemyTrasform;

    public bool starSpawning;
    public Vector3 offSet;

    private readonly float roadWide = 2f;

    void Start()
    {
        starSpawning = true;
        StartCoroutine(Spawnning());
    }

    void Update()
    {
        Vector3 spawnPos = playerTransform.position + offSet;
        spawnPos.x = Random.Range(-roadWide, roadWide);
        this.gameObject.transform.position = new Vector3(spawnPos.x, spawnPos.y, spawnPos.z);
    }

    void SpawnObject(Vector3 spawnPosition)
    {
        GameObject enemy;
        //Debug.Log("Spawn MumMy");
        enemy = Instantiate(objectToSpawn[RandomObstacle()], spawnPosition, Quaternion.AngleAxis(180, Vector3.up));
        enemy.transform.SetParent(enemyTrasform);
    }

    public IEnumerator Spawnning()
    {
        while (starSpawning)
        {
            // Debug.Log("Ready to Spawn");
            float timeSpawn = Random.Range(0, intervalSpawn + 1);
            yield return new WaitForSeconds(timeSpawn);
            SpawnObject(this.gameObject.transform.position);
        }
    }

    int RandomObstacle()
    {
        int indexObstacle;
        indexObstacle = Random.Range(0, objectToSpawn.Length);
        return indexObstacle;
    }
}

