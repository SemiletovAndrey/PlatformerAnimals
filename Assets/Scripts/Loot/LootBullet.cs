using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBullet : MonoBehaviour
{

    [SerializeField] private int gunIndex;
    [SerializeField] private int numberOfBullets;

    private void OnTriggerEnter(Collider other)
    {
        PlayerArmory playerArmory = other.attachedRigidbody.GetComponent<PlayerArmory>();
        if (playerArmory != null)
        {
            playerArmory.AddBullets(gunIndex, numberOfBullets);
            Destroy(gameObject);
        }

    }
}
