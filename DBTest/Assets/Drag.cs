using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drag : MonoBehaviour
{

    // Use this for initialization
    float distance = 10;
    void OnMouseDrag()
    {
        Vector3 mouseposition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mouseposition);
        transform.position = objPosition;

    }
}
