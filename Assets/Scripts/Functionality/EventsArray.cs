using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsArray : MonoBehaviour
{
    [SerializeField] private UnityEvent[] eventsCall;
    public void StartEvent(int eventIndex)
    {
        eventsCall[eventIndex].Invoke();
    }
}
