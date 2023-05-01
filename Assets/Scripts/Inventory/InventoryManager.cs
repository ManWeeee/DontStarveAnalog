using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    Inventory _inventory;
    [SerializeField]
    InventoryUISlot[] slots;

    private void Start()
    {
        slots = GetComponentsInChildren<InventoryUISlot>();
    }

    private void OnEnable()
    {
        _inventory.OnInventoryChanged += UpdateInventory;
    }

    private void UpdateInventory(object sender, EventArgs e)
    {
       for (int i = 0; i < _inventory.inventory.Count; i++) 
       {
            slots[i].Visible(_inventory.inventory[i]);
            slots[i].ChangeIcon(_inventory.inventory[i].GetItem.GetSprite);
            /*slots[i].Invisible();*/
       }
    }
}
