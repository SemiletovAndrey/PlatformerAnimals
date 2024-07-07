using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatchPrefabCreator : MonoBehaviour
{

    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform[] spawns;

    [ContextMenu("Create")]
    public void Create()
    {
        for(int i = 0; i < spawns.Length; i++)
        {
            Instantiate(prefab, spawns[i].position, spawns[i].rotation);
        }
    }
}
