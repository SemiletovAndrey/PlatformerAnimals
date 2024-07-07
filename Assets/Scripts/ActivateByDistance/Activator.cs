using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    [SerializeField] private List<ActivateByDistance> objectsToActivate;
    [SerializeField] private Transform playerTransform;

    public void AddObjectsInListToActivate(ActivateByDistance activateByDistance)
    {
        objectsToActivate.Add(activateByDistance);
    }

    public void RemoveObjectsInListToActivate(ActivateByDistance activateByDistance)
    {
        objectsToActivate.Remove(activateByDistance);
    }

    private void Update()
    {
        for (int i = 0; i < objectsToActivate.Count; i++)
        {
            objectsToActivate[i].CheckDistance(playerTransform.position);
        }
    }
}
