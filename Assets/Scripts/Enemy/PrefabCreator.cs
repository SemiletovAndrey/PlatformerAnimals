using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabCreator : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform spawn;

    public void Create()
    {
        Vector3 spawnPos = new Vector3(spawn.position.x, spawn.position.y,0);
        Instantiate(prefab, spawnPos, spawn.rotation);
    }
}
