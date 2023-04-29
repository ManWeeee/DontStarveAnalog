using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using static UnityEditor.Progress;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    float _speed;
    Vector3 _dir;
    Rigidbody2D _rb;
    Inventory _inventory;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _inventory = GetComponent<Inventory>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _inventory.ItemToPick)
        {
            _inventory.AddItem();
            PrintInventory();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void PrintInventory()
    {
        _inventory.ShowInventory();
    }

    private void Move()
    {
        _dir.x = Input.GetAxisRaw("Horizontal");
        _dir.y = Input.GetAxisRaw("Vertical");
        if(_dir.magnitude > 1f)
            _dir.Normalize();
        Vector2 _movement = _dir * _speed * Time.deltaTime;
        _rb.MovePosition(_rb.position + _movement);
    }
}
