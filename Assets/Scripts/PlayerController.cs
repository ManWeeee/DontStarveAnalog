using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using static UnityEditor.Progress;
using System;

[RequireComponent(typeof(Inventory))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    float _speed;
    Vector3 _dir;
    Rigidbody2D _rb;
    Inventory _inventory;

    private void Awake()
    {
        _inventory = GetComponent<Inventory>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _inventory.OnInventoryChanged += PrintInventory;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void PrintInventory(object sender, EventArgs e)
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
