using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent (typeof(SpriteRenderer))]
public class CollectableItem : MonoBehaviour
{
    [SerializeField]
    private Item item;
    [SerializeField]
    private int amount = 1;
    SpriteRenderer spr;


    private void Awake()
    {
        if(amount > item.GetMaxStack) 
            amount = item.GetMaxStack;
        spr = GetComponent<SpriteRenderer>();

        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        collider.radius = item.GetHarvestRadius;
        collider.isTrigger = true;
    }

    private void OnEnable()
    {
        spr.sprite = item.GetSp;
    }

    public void Harvest()
    {
        Destroy(gameObject);
        Debug.Log("Harvested");
    }
    
    public Item GetItem
    {
        get { return item; }
    }

    public int Amount
    {
        get { return amount; }
        set { amount = value; }
    }
}
