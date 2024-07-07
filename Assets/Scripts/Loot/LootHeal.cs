using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootHeal : MonoBehaviour
{
    [SerializeField] private int healthValue = 1;
    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.attachedRigidbody.GetComponent<PlayerHealth>();
        if(playerHealth != null)
        {
            if (playerHealth.Health < playerHealth.MaxHealth)
            {
                playerHealth.AddHealth(healthValue);
                Destroy(gameObject);
            }
        }

    }
}
