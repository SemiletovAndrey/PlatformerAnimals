using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private Vector3 rotationSpeedVector;



    private void Update()
    {
        transform.Rotate(rotationSpeedVector * Time.deltaTime);
    }
}
