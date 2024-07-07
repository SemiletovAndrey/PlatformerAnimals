using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    [SerializeField] private Transform headTarget;


    void Update()
    {
        transform.position = headTarget.position;
    }
}
