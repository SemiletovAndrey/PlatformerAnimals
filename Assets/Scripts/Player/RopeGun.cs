using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RopeState
{
    Disabled,
    Fly,
    Active
}
public class RopeGun : MonoBehaviour
{
    [SerializeField] private Hook hook;
    [SerializeField] private Transform spawn;
    [SerializeField] private Transform ropeStart;
    [SerializeField] private float speed;
    [SerializeField] private float maxDistanceRope = 15f;

    [SerializeField] private SpringJoint springJoint;
    [SerializeField] private RopeState curentRopeState;

    [SerializeField] private RopeRenderer ropeRenderer;
    [SerializeField] private PlayerMove playerMove;

    private float _length;
    private void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            Shot();
        }
        if (curentRopeState == RopeState.Fly)
        {
            float distance = Vector3.Distance(ropeStart.position, hook.transform.position);
            if (distance > maxDistanceRope)
            {
                hook.gameObject.SetActive(false);
                curentRopeState = RopeState.Disabled;
                ropeRenderer.Hide();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (curentRopeState == RopeState.Active)
            {
                if (playerMove.Grounded == false)
                {
                    playerMove.Jump();
                }
            }
            DestroySpring();
        }

        if (curentRopeState == RopeState.Active || curentRopeState == RopeState.Fly)
        {
            ropeRenderer.Draw(ropeStart.position, hook.transform.position, _length);
        }
    }

    private void Shot()
    {
        _length = 1f;
        if (springJoint)
        {
            Destroy(springJoint);
        }
        hook.gameObject.SetActive(true);
        hook.StopFix();
        hook.transform.position = spawn.position;
        hook.transform.rotation = spawn.rotation;
        hook.rigidbody.velocity = spawn.forward * speed;
        curentRopeState = RopeState.Fly;
    }

    public void CreateSpring()
    {
        if (springJoint == null)
        {
            springJoint = gameObject.AddComponent<SpringJoint>();
            springJoint.connectedBody = hook.rigidbody;
            springJoint.autoConfigureConnectedAnchor = false;
            springJoint.connectedAnchor = Vector3.zero;
            springJoint.spring = 100f;
            springJoint.damper = 5.0f;
            springJoint.anchor = ropeStart.localPosition;
            _length = Vector3.Distance(ropeStart.position, hook.transform.position);
            springJoint.maxDistance = _length;

            curentRopeState = RopeState.Active;

        }
    }

    public void DestroySpring()
    {
        if (springJoint != null)
        {
            Destroy(springJoint);
            curentRopeState = RopeState.Disabled;
            hook.gameObject.SetActive(false);
            ropeRenderer.Hide();
        }
    }
}
