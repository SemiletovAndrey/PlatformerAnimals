using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private bool DieOnAnyCollision;

    private void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            Bullet bullet = collision.rigidbody.GetComponent<Bullet>();
            if (bullet != null)
            {
                enemyHealth.TakeDamage(bullet.Damage);
            }
        }
        if (DieOnAnyCollision == true)
        {
            enemyHealth.TakeDamage(100);
        }
        
    }
}
