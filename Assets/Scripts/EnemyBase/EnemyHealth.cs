using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 1;
    [SerializeField] private UnityEvent EventOnTakeDamage;
    [SerializeField] private UnityEvent EventOnDie;

    public void TakeDamage(int damageValue)
    {
        health -= damageValue;
        if (health <= 0)
        {
            Die();
        }
        EventOnTakeDamage.Invoke();
    }

    public void Die()
    {
        EventOnDie.Invoke();
        Destroy(gameObject);
    }
}
