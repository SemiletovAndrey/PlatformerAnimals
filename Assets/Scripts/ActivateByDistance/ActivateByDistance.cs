#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class ActivateByDistance : MonoBehaviour
{
    [SerializeField] private float distanceToActivate = 20;

    private bool _isActive = true;
    private Activator _activator;

    private void Start()
    {
        _activator = FindObjectOfType<Activator>();
        _activator.AddObjectsInListToActivate(this);
    }
    public void CheckDistance(Vector3 playerPosition)
    {
        float distance = Vector3.Distance(transform.position, playerPosition);
        if(_isActive)
        {
            if (distance > distanceToActivate + 2f)
            {
                Deactivate();
            }
        }
        else
        {
            if (distance < distanceToActivate)
            {
                Activate();
            }
        } 
    }

    private void OnDestroy()
    {
        _activator.RemoveObjectsInListToActivate(this);
    }

    public void Activate()
    {
        _isActive = true;
        gameObject.SetActive(true);
    }
    public void Deactivate()
    {
        _isActive = false;
        gameObject.SetActive(false);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.DrawWireDisc(transform.position, Vector3.forward, distanceToActivate);
    }
#endif

}
