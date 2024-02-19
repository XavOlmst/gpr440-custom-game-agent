using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<Item> inventory = new();   
    [SerializeField] private int currentCurrency;

    public List<Item> GetInventory() => inventory;
    
    public int GetCurrency() => currentCurrency;
    public void AddCurrency(int currency) => currentCurrency += currency;
    
    public bool RemoveCurrency(int currency)
    {
        if (currentCurrency - currency < 0)
            return false;

        currentCurrency -= currency;
        return true;
    }

    public bool RemoveItem(Item item)
    {
        if (!inventory.Contains(item)) return false;

        inventory.Remove(item);
        return true;
    }
    
    public void AddItem(Item item) => inventory.Add(item);
}
