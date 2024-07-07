using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float timeScale = 0.02f;

    private float _startTimeFixedDeltaTime;
    

    private void Start()
    {
        _startTimeFixedDeltaTime = Time.fixedDeltaTime;
    }
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Time.timeScale = timeScale;
            Time.fixedDeltaTime = _startTimeFixedDeltaTime * Time.timeScale;

        }
        else
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = _startTimeFixedDeltaTime * Time.timeScale;

        }
    }

    private void OnDestroy()
    {
        Time.fixedDeltaTime = _startTimeFixedDeltaTime;
    }
}
