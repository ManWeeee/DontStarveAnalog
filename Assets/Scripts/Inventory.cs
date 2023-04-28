using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    int maxSize = 3;
    private List<InventorySlot> _inventory = new List<InventorySlot>();
    private PlayerController _playerController;
    Vector2 _offset = new Vector3(0.0f, 0.5f);

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
    }

    public int AddItem(Item newItem, int amount)
    {
        foreach (InventorySlot slot in _inventory)
        {
            if (slot.Item.Id == newItem.Id)
            {
                if (slot.Amount + amount <= slot.MaxStack)
                {
                    slot.Amount += amount;
                    amount = 0;
                    return amount;
                }
                else
                {
                    while (slot.Amount < slot.MaxStack)
                    {
                        slot.Amount += 1;
                        amount -= 1;
                    }
                }
            }
        }
        
        while (amount > newItem.MaxStack && MaxSize)
        {
            _inventory.Add(new InventorySlot(newItem, newItem.MaxStack));
            amount -= newItem.MaxStack;
        }

        if (MaxSize)
        {
            _inventory.Add(new InventorySlot(newItem, amount));
            amount = 0;
        }
        return amount;
/*        else
        {
            //CollectableItem tmp = new CollectableItem(newItem, amount);
            //Use Prefab
            //Instantiate(tmp, _playerController.GetComponent<Rigidbody2D>().position - _offset, Quaternion.identity);
        }*/
    }

    public bool MaxSize
    {
        get { return _inventory.Count < maxSize; }
    }

    public void ShowInventory()
    {
        foreach(InventorySlot slot in _inventory)
            Debug.Log($"Name: {slot.Item.Name}, Id: {slot.Item.Id}, Amount: {slot.Amount}");
    }
}
