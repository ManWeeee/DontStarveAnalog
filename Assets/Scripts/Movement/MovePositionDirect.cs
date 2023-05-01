using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePositionDirect : MonoBehaviour
{
    Vector3 movePosition;

    public void SetPosition(Vector3 movePosition)
    {
        this.movePosition = movePosition;
    }

    private void Update()
    {
        Vector3 moveDir = (movePosition - transform.position).normalized;
        Debug.Log(moveDir.magnitude);
        GetComponent<IMoveVelocity>().SetVelocity(moveDir);
    }
}
