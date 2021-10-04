using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMoveObject : MonoBehaviour
{
    public Transform objectToMove;

    void OnMouseDown()
    {
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        print(worldPosition.x);
        print(worldPosition.y);
    }
}
