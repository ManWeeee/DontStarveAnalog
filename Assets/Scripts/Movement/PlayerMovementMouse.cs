using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementMouse : MonoBehaviour
{ 
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<MovePositionDirect>().SetPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}
