using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitGenerator : MonoBehaviour
{
    [SerializeField] GameObject resource;
    [SerializeField] Transform spawnPoint;

    public void SpawnResource()
    {
        Instantiate(resource, spawnPoint.position, transform.rotation);
    }
}
