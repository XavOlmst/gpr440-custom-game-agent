using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private List<Item> sellingItems;
    [Range(1,2)][SerializeField] private float sellRate = 1.15f;
    [Range(0,1)][SerializeField] private float buyRate = 0.75f;

    private void Start()
    {
        SellItem(sellingItems[0]);
    }

    public bool SellItem(Item item)
    {
        if (!sellingItems.Contains(item)) return false;

        if (playerInventory.RemoveCurrency(Mathf.FloorToInt(item.ItemCost * sellRate)))
        {
            playerInventory.AddItem(item);
            return true;
        }

        return false;
    }

    public bool BuyItem(Item item)
    {
        if (playerInventory.RemoveItem(item))
        {
            playerInventory.AddCurrency(Mathf.CeilToInt(item.ItemCost * buyRate));
            return true;
        }
        
        return false;
    }
}
