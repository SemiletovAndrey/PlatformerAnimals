using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]  
public class Carrot : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbodyCarrot;
    [SerializeField] private float speedCarrot;
    void Start()
    {
        transform.rotation = Quaternion.identity;
        rigidbodyCarrot = GetComponent<Rigidbody>();
        Transform playerTransform = FindObjectOfType<PlayerMove>().transform;
        Vector3 toPlayer = (playerTransform.position - transform.position).normalized;
        rigidbodyCarrot.velocity = toPlayer * speedCarrot;
    }

    
}
