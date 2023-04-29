using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    int maxSize = 2;
    private List<InventorySlot> _inventory = new List<InventorySlot>();
    private PlayerController _playerController;
    Vector2 _offset = new Vector3(0.0f, 0.5f);
    List<CollectableItem> _itemToPick = new List<CollectableItem>();

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<CollectableItem>(out CollectableItem item))
        {
            _itemToPick.Add(item);
            Debug.Log($"{item.GetItem.GetName} : {item.Amount}");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _itemToPick.Remove(collision.gameObject.GetComponent<CollectableItem>());
    }

    public void AddItem()
    {
        CollectableItem item = _itemToPick[0];
        foreach (InventorySlot slot in _inventory)
        {
            if (slot.GetItem.GetId == item.GetItem.GetId)
            {
                if (slot.Amount + item.Amount <= slot.GetMaxStack)
                {
                    slot.Amount += item.Amount;
                    item.Amount = 0;
                    item.Harvest();
                    return;
                }
                else
                {
                    item.Amount -= slot.GetMaxStack - slot.Amount;
                    slot.Amount = slot.GetMaxStack;
                }
            }
        }

        if (MaxSize)
        {
            _inventory.Add(new InventorySlot(item.GetItem, item.Amount));
            item.Harvest();
        }
        return;
    }

    public bool MaxSize
    {
        get { return _inventory.Count < maxSize; }
    }

    public bool ItemToPick
    {
        get { return _itemToPick.Count > 0; }       
    }

    public void ShowInventory()
    {
        foreach(InventorySlot slot in _inventory)
            Debug.Log($"Name: {slot.GetItem.GetName}, Id: {slot.GetItem.GetId}, Amount: {slot.Amount}");
    }
}
