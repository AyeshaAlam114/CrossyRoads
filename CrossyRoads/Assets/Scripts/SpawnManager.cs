using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject groundSetPrefab;
    public Transform spawnPosition;
    public GameObject groundParent;

    public void SpawnGroundPatch()
    {
        GameObject groundSet = Instantiate(groundSetPrefab, spawnPosition.position, Quaternion.identity, groundParent.transform);
        groundSet.transform.GetChild(0).transform.position = spawnPosition.position;
        spawnPosition.position = groundSet.transform.GetChild(1).transform.position;
    }
}
