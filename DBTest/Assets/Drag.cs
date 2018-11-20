using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
    private Vector3 offset;

    void OnMouseDown()
    {

        offset = gameObject.transform.position -
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1000.0f));
      //  Debug.Log("on mouse down");
    }

    void OnMouseDrag()
    {
        Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1000.0f);
        transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
       // Debug.Log("on mouse drag");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       // Debug.Log("respuesta 3");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "p1")
        {
            Debug.Log("Colisionamos con p1 el objeto "+this.name);
        }
        if (collision.gameObject.tag == "p2")
        {
            Debug.Log("Colisionamos con p2 el objeto "+this.name);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       // Debug.Log("salio del obj");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
      //  Debug.Log("ESTA EN EL OBJ");
    }

}
