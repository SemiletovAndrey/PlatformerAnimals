using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    private FixedJoint _fixedJoint;
    public Rigidbody rigidbody;

    [SerializeField] private Collider collider;
    [SerializeField] private Collider playerCollider;
    [SerializeField] private RopeGun ropeGun;

    private void Start()
    {
        Physics.IgnoreCollision(collider, playerCollider);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (_fixedJoint == null)
        {
            _fixedJoint = gameObject.AddComponent<FixedJoint>();
            if(collision.rigidbody != null)
            {
                _fixedJoint.connectedBody = collision.rigidbody;
            }
            ropeGun.CreateSpring();
        }
    }


    public void StopFix()
    {
        if (_fixedJoint)
        {
            Destroy(_fixedJoint);
        }
    }

}
