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
    Vector3 mousePosition;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

    }

    private void FixedUpdate()
    {
        Move();
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
