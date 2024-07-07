using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public enum Direction
{
    Left,
    Right
}

public class Walker : MonoBehaviour
{
    [SerializeField] private Transform leftTarget;
    [SerializeField] private Transform rightTarget;
    [SerializeField] private Transform rayStart;

    [SerializeField] private float speed;
    [SerializeField] private float stopTime;

    [SerializeField] private Direction currentDirection;

    [SerializeField] private UnityEvent eventOnLeftTarget;
    [SerializeField] private UnityEvent eventOnRightTarget;
    private bool _isStopped;

    private Vector3 leftPoint;
    private Vector3 rightPoint;
    private void Start()
    {
        leftPoint = leftTarget.position;
        rightPoint = rightTarget.position;
        leftTarget.gameObject.SetActive(false);
        rightTarget.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(_isStopped) return;

        if (currentDirection == Direction.Left)
        {
            transform.position -= new Vector3(Time.deltaTime * speed, 0, 0);
            if (transform.position.x < leftPoint.x)
            {
                currentDirection = Direction.Right;
                _isStopped = true;
                Invoke(nameof(ContinueWalk), stopTime);
                eventOnLeftTarget.Invoke();
            }
        }
        else
        {
            transform.position += new Vector3(Time.deltaTime * speed, 0, 0);
            if (transform.position.x > rightPoint.x)
            {
                currentDirection = Direction.Left;
                _isStopped = true;
                Invoke(nameof(ContinueWalk), stopTime);
                eventOnRightTarget.Invoke();
            }
        }

        RaycastHit hit;
        if(Physics.Raycast(rayStart.position, Vector3.down, out hit))
        {
            transform.position = hit.point;
        }
    }

    private void ContinueWalk()
    {
        _isStopped = false;
    }
}
