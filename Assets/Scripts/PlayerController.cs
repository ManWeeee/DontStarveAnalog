using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    float _speed;
    Vector3 _dir;
    Rigidbody2D _rb;
    Inventory _inventory;
    CollectableItem _itemToPick;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _inventory = GetComponent<Inventory>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _itemToPick != null)
        {
            Grab(_itemToPick);
        }
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<CollectableItem>(out CollectableItem item))
        {
            _itemToPick = item;
            Debug.Log(_itemToPick.Item.Name);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _itemToPick = null;
    }

    private void Grab(CollectableItem item)
    {
        _inventory.AddItem(item.Item, item.Amount);
        Debug.Log("Item was grabbed");
        item.Harvest();
    }

    private void Move()
    {
        _dir.x = Input.GetAxisRaw("Horizontal");
        _dir.y = Input.GetAxisRaw("Vertical");
        if(_dir.magnitude > 1f)
        {
            _dir.Normalize();
        }
        Vector2 _movement = _dir.normalized * _speed * Time.deltaTime;
        _rb.MovePosition(_rb.position + _movement);
    }
}
