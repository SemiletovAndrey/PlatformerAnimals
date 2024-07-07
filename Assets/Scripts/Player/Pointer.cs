using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Transform aimTransform;
    [SerializeField] private Camera playerCamera;

    //решение вращения игрока к мыши от создателя курса
    [SerializeField] Transform Body;
    float _yEuler;

    private void LateUpdate()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction *50f, Color.yellow);
        Plane plane = new Plane(-Vector3.forward, Vector3.zero);
        float distance;
        plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);
        aimTransform.position = point;

        Vector3 toAim = aimTransform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);

        if (toAim.x < 0)
        {
            _yEuler = Mathf.Lerp(_yEuler, 45f, Time.deltaTime * 8f);
        }
        else
        {
            _yEuler = Mathf.Lerp(_yEuler, -45f, Time.deltaTime * 8f);
        }
        Body.localEulerAngles = new Vector3(0, _yEuler, 0);
    }
}
