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
    Sprite sp;

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();

        CircleCollider2D collider = gameObject.GetComponent<CircleCollider2D>();

        collider.radius = item.HarvestRadius;

        collider.isTrigger = true;
    }

    private void Start()
    {
        sp = item.Sp;
        spr.sprite = sp;
    }

    public void Harvest(int amount)
    {
        if (amount == 0)
            Destroy(gameObject);
        else
            this.amount = amount;

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
