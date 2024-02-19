using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Mob")]
public class Mob : ScriptableObject
{
    public string Name;
    public Sprite sprite;
    public float Health;

    public bool IsAggressive;
    
    public float Damage;
    public float AttackRange;
    public float AttackSpeed;

    public List<DropTable<Item, float, Vector2Int>> DropsWithWeights;
}

[CustomEditor(typeof(Mob))]
public class MobEditor : Editor
{
    private Mob targetMob;

    private void OnEnable()
    {
        targetMob = target as Mob;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (targetMob.IsAggressive)
        {
            
        }
    }
}

[Serializable]
public class Pair<T, TK>
{
    Pair(T first, TK second)
    {
        this.first = first;
        this.second = second;
    }
    
    public T first;
    public TK second;
}

[Serializable]
public class DropTable<T, K, U>
{
    public DropTable(T first, K second, U third)
    {
        drop = first;
        chance = second;
        rolls = third;
    }
    
    public T drop;
    public K chance;
    public U rolls;
}