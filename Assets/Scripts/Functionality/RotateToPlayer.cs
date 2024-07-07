using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 leftEuler;
    [SerializeField] private Vector3 rightEuler;
    [SerializeField] private float rotationSpeed = 5f;

    private Vector3 _targetEuler;
    private Transform _transformPlayer;

    void Start()
    {
        _transformPlayer = FindObjectOfType<PlayerMove>().transform;
    }

    
    void Update()
    {
        if(transform.position.x < _transformPlayer.position.x)
        {
            //Повернуть направо 
            _targetEuler = rightEuler;
        }
        else
        {
            //Повернуть налево
            _targetEuler = leftEuler;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_targetEuler), Time.deltaTime * rotationSpeed);

    }
}
