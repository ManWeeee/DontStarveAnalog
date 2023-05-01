using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementKeys : MonoBehaviour
{
    Vector3 _dir;

    private void Update()
    {
        _dir.x = Input.GetAxisRaw("Horizontal");
        _dir.y = Input.GetAxisRaw("Vertical");
        GetComponent<IMoveVelocity>().SetVelocity(_dir.normalized);
    }
}
