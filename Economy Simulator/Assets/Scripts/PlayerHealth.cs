using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private TMP_Text healthText;
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

        healthText.text = $"HP: {health}";
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        Debug.Log($"Player Health: {health}");
    }
}
