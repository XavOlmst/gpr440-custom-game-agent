using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Mob data;

    private void Start()
    {
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
                }
            }
        }
    }
}
