using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private bool DieOnAnyCollision;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            Bullet bullet = other.attachedRigidbody.GetComponent<Bullet>();
            if (bullet != null)
            {
                enemyHealth.TakeDamage(bullet.Damage);
                bullet.ShotEffect();
            }
        }
        

        if (DieOnAnyCollision == true)
        {
            if (other.isTrigger == false)
            {
                enemyHealth.TakeDamage(100);
            }
        }

    }
}
