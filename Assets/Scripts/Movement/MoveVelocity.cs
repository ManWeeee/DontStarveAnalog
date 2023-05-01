using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVelocity : MonoBehaviour, IMoveVelocity
{
    [SerializeField]
    float speed;
    Vector3 _velocityVector;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetVelocity(Vector3 velocityVector)
    {
        this._velocityVector = velocityVector;
    }

    private void FixedUpdate()
    {
        Vector2 _moveDir = _velocityVector * speed * Time.deltaTime;
        rb.position = rb.position + _moveDir;
    }
}
