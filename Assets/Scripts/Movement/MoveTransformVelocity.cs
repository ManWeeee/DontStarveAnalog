using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransformVelocity : MonoBehaviour, IMoveVelocity
{
    [SerializeField]
    float speed;
    Vector3 _velocityVector;

    public void SetVelocity(Vector3 velocityVector)
    {
        this._velocityVector = velocityVector;
    }

    private void Update()
    {
        transform.position += _velocityVector * speed * Time.deltaTime;
    }
}
