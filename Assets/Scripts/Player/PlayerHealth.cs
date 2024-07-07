using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 5;
    [SerializeField] private int maxHealth = 8;
    [SerializeField] private HealthUI healthUI;
    [SerializeField] private AudioSource AddHealthSound;
    [SerializeField] private UnityEvent EventOnTakeDamage;


    public int Health { get { return health; } }
    public int MaxHealth { get { return maxHealth; } }
    private bool _invulnerable = false;

    private void Start()
    {
        healthUI.Setup(maxHealth);
        healthUI.DisplayHealth(health);
    }

    public void TakeDamage(int damageValue)
    {
        if(_invulnerable == false)
        {
            health -= damageValue;
            if (health <= 0)
            {
                health = 0;
                Die();
            }
            _invulnerable = true;
            Invoke(nameof(StopInvulnerable), 1f);
            healthUI.DisplayHealth(health);
            EventOnTakeDamage.Invoke();
        }
    }

    private void StopInvulnerable()
    {
        _invulnerable = false;
    }

    public void AddHealth(int healthValue)
    {
        health += healthValue;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        AddHealthSound.Play();
        healthUI.DisplayHealth(health);
    }

    private void Die()
    {
        Debug.Log("You Lose");
    }
}
