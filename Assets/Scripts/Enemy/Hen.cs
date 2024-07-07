using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Hen : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbodyHen;
    [SerializeField] private float speedHen = 3;
    [SerializeField] private float timeToReachSpeed = 1;

    private Transform playerTransform;

    void Start()
    {
        rigidbodyHen = GetComponent<Rigidbody>();
        playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    
    void FixedUpdate()
    {
        Vector3 toPlayer = (playerTransform.position - transform.position).normalized;
        Vector3 force = rigidbodyHen.mass * (toPlayer * speedHen - rigidbodyHen.velocity) / timeToReachSpeed;
        rigidbodyHen.AddForce(force);
    }
}
