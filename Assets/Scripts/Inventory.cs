using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    int maxSize = 10;
    private List<InventorySlot> _inventory = new List<InventorySlot>();
    private PlayerController _playerController;
    Vector3 _offset = new Vector3(0.0f, 0.5f, 0.0f);

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
    }

    public void AddItem(Item newItem, int amount)
    {
        foreach (InventorySlot slot in _inventory)
        {
            Debug.Log($"{slot.Item.Name} is in inventory id's {slot.Item.Id} and {newItem.Id}");
            
            if (slot.Item.Id == newItem.Id)
                if (slot.Amount + amount <= slot.MaxStack)
                {
                    slot.Amount += amount;
                    Debug.Log($"Item {newItem.Name} was succesfully added to existed slot of inventory and now its {slot.Amount}");
                    return;
                }
                else
                {
                    while (slot.Amount < slot.MaxStack)
                    {
                        slot.Amount += 1;
                        amount -= 1;
                    }
                    Debug.Log("MaxStack choosed");
                    if (_inventory.Count <= maxSize)
                    { 
                        _inventory.Add(new InventorySlot(newItem, amount));
                        Debug.Log($"Added to {_inventory.Count} slot");
                        return;
                    }
                    else
                    {
                        Instantiate(newItem, _playerController.transform.position - _offset, Quaternion.identity);
                        return;
                    }
                }
        }
        _inventory.Add(new InventorySlot(newItem, amount));
        Debug.Log($"Item {newItem.Name} was succesfully added to inventory");
    }
    public void ShowInventory()
    {
        foreach(InventorySlot slot in _inventory)
        {
            Debug.Log($"Name: {slot.Item.Name}, Id: {slot.Item.Id}, Amount: {slot.Amount}");
        }
    }
}
