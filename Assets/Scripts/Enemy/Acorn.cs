using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    [SerializeField] private Vector3 velocity;
    [SerializeField] private float maxRotationSpeed;

    private Rigidbody _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddRelativeForce(velocity, ForceMode.VelocityChange);
        _rigidbody.angularVelocity = new Vector3(Random.Range(-maxRotationSpeed, maxRotationSpeed),
            Random.Range(-maxRotationSpeed, maxRotationSpeed),
            Random.Range(-maxRotationSpeed, maxRotationSpeed)
            );
    }
}
