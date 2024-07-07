using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTriggerEveryNSecond : MonoBehaviour
{
    [SerializeField] private float period = 7f;
    [SerializeField] private Animator animator;
    [SerializeField] private string triggerName = "Attack";

    private void OnEnable()
    {
        StartCoroutine(AttackWithPeriod());
    }
    private IEnumerator AttackWithPeriod()
    {
        while (true)
        {
            yield return new WaitForSeconds(period);
            animator.SetTrigger(triggerName);
        }
    }
}
