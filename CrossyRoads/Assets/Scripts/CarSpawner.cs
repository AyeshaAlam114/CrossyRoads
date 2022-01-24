using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public Transform[] spawnPosition;
    public GameObject[] vehiclePrefab;
    int vehicleIndex;
    int positionIndex;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SetIndexes", 0.1f, 1.5f);
    }

    void SpawnVehicle()
    {
       Instantiate(vehiclePrefab[vehicleIndex], spawnPosition[positionIndex].position, spawnPosition[positionIndex].rotation, this.transform);

    }
    void SetIndexes()
    {
        positionIndex = Random.Range(0, spawnPosition.Length);
        vehicleIndex = Random.Range(0, vehiclePrefab.Length);
        Invoke(nameof(SpawnVehicle), 0.2f);
    }
}
