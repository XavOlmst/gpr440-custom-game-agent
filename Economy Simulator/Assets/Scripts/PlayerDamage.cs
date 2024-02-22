using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private float attackDamage;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float attackRadius;
    private float invertedAtkSpd;
    private float attackTimer = 0;
    
    private void Awake()
    {
        invertedAtkSpd = 1 / attackSpeed;
    }

    private void Update()
    {
        attackTimer -= Time.deltaTime;

        if (attackTimer < 0 && Input.GetKeyDown(KeyCode.E))
        {
            attackTimer = invertedAtkSpd;

            List<Enemy> allEnemies = new();
            allEnemies.AddRange(FindObjectsOfType<Enemy>());

            foreach (var enemy in allEnemies)
            {
                Damage(enemy);
            }
        }
    }

    public void Damage(Enemy enemy)
    {
        if (Vector2.Distance(enemy.transform.position, transform.position) < attackRadius)
        {
            enemy.TakeDamage(attackDamage);
        }
    }
}
