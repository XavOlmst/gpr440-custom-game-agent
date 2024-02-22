using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Mob data;
    private PlayerInventory playerInventory;
    private float health;
    private float attackTimer = 0;
    private void Awake()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
        attackTimer = 1 / data.AttackSpeed;
        health = data.Health;
    }

    //this is so expensive, lol
    private void Update()
    {
        attackTimer -= Time.deltaTime;
        
        Vector2 position = transform.position;
        Vector2 playerPosition = playerInventory.transform.position;
        if (data.IsAggressive && Vector2.Distance(playerPosition, position) <
            data.DetectionRange)
        {
            if (Vector2.Distance(playerPosition, position) < data.AttackRange)
            {
                if (attackTimer < 0)
                {
                    playerInventory.GetComponent<PlayerHealth>().TakeDamage(data.Damage);
                    attackTimer = 1 / data.AttackSpeed;
                }
            }
            else
            {
                transform.position = Vector2.MoveTowards(position, playerPosition, data.MoveSpeed * Time.deltaTime);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        
        if(health <= 0)
            OnDeath();
    }
    
    public void OnDeath()
    {
        foreach (var drop in data.DropsWithWeights)
        {
            int rolls = Random.Range(drop.rolls.x, drop.rolls.y + 1);

            for (int i = 0; i < rolls; i++)
            {
                float roll = Random.value;

                if (roll < drop.chance / 100.0f)
                {
                    Debug.Log($"{data.Name} has dropped: {drop.drop.ItemName}");
                    playerInventory.AddItem(drop.drop);
                }
            }
        }
        
        Destroy(gameObject);
    }
}
