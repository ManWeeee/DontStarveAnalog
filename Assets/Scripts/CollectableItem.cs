using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class CollectableItem : MonoBehaviour
{
    [SerializeField]
    private Item item;
    [SerializeField]
    private int amount = 1;

    public void Harvest()
    {
        Destroy(gameObject);
        Debug.Log("Harvested");
    }
    
    public Item Item
    {
        get { return item; }
    }

    public int Amount
    {
        get { return amount; }
    }
}
