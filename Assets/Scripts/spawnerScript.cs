using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    public GameObject[] objectsToSpawn; 
    public float spawnInterval = 2f; 
    public bool isSpawner1 = true; 
    private List<GameObject> spawnedObjects = new List<GameObject>(); 

    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            if (spawnedObjects.Count < 4)
            {
                GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];
                GameObject spawnedObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
                spawnedObjects.Add(spawnedObject);

                if (isSpawner1)
                {
                    spawnedObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                }
                else
                {
                    spawnedObject.transform.rotation = Quaternion.Euler(0f, -180f, 0f);
                }
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void Update()
    {
        for (int i = spawnedObjects.Count - 1; i >= 0; i--)
        {
            if (spawnedObjects[i] == null)
            {
                spawnedObjects.RemoveAt(i);
            }
        }
    }
}
