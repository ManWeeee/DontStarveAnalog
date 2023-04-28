using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    Item item;
    int amount;
    int maxStack;

    public InventorySlot(Item item, int amount)
    {
        this.item = item;
        this.amount = amount;
        maxStack = item.MaxStack;
    }

    public Item Item 
    { 
        get { return item; }
    }
    
    public int Amount
    {
        get { return amount; }
        set { amount = value; }
    }

    public int MaxStack
    {
        get { return maxStack; }
    }
}
