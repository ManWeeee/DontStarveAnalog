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

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        sp = item.Sp;
        spr.sprite = sp;
    }

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
