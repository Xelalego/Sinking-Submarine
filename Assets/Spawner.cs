using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> SpawnObjects = new();

    [SerializeField]
    private float Cooldown = 15f;

    private float NextSpawn;

    // Start is called before the first frame update
    void Start()
    {
        NextSpawn = -Mathf.Infinity;
    }

    public void Spawn()
    {
        if (Time.time >= NextSpawn)
        {
            NextSpawn = Time.time + Cooldown;
            if (SpawnObjects.Count > 0)
            {
                GameObject spawnedObject = Instantiate(SpawnObjects[Random.Range(0, SpawnObjects.Count)]);
                spawnedObject.transform.position = transform.position;
            }
            else
            {
                Debug.LogWarning(gameObject.name + " has no spawnable items");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
