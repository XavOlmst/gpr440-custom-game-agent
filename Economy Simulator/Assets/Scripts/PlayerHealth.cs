using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private Item healingPotion;
    [SerializeField] private float maxHealth = 15f;
    [SerializeField] private float healingValue;

    private float health;

    private void Awake()
    {
        health = maxHealth;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            Heal();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            TakeDamage(2.0f);
        }
    }

    private void Heal()
    {
        if (inventory.GetInventory().Contains(healingPotion))
        {
            inventory.RemoveItem(healingPotion);

            health += healingValue;

            if (health > maxHealth) health = maxHealth;
        }
        
        Debug.Log($"Player Health: {health}");
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Debug.Log("Player Died, womp womp");
        }

        Debug.Log($"Player Health: {health}");
    }
}
