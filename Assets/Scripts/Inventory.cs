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
            if (slot.Item.Id == newItem.Id)
                if (slot.Amount + amount <= slot.MaxStack)
                {
                    slot.Amount += amount;
                    Debug.Log($"Item {newItem.Name} was succesfully added to existed slot of inventory and now its {slot.Amount}");
                    return;
                }
                    
                else
                {
                    while (slot.Amount <= slot.MaxStack)
                    {
                        slot.Amount += 1;
                        amount -= 1;
                    }
                    if (_inventory.Count <= maxSize)
                    {
                        _inventory.Add(new InventorySlot(newItem, amount));
                    }
                    else
                    {
                        Instantiate(newItem, _playerController.transform.position - _offset, Quaternion.identity);
                    }
                }
        }
        _inventory.Add(new InventorySlot(newItem, 1));
        Debug.Log($"Item {newItem.Name} was succesfully added to inventory");
    }
}
