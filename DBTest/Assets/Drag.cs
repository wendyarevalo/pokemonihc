using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
    private Vector3 offset;

    bool isdragging = false;
    int lastQuestion = -1;
    GameObject lastQuestionSprite;

    void OnMouseDown()
    {
        isdragging = true;
        offset = gameObject.transform.position -
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1000.0f));
      //  Debug.Log("on mouse down");
    }
    void OnMouseUp()
    {
        isdragging = false;
        //TextMesh puntos = GameObject.Find("Npuntuacion");
        
        
        switch (lastQuestion)
        {
            case 0:
                Debug.Log("Colisionamos con p1 el objeto " + this.name);
                break;
            case 1:
                Debug.Log("Colisionamos con p2 el objeto " + this.name);
                break;
            case 2:
                Debug.Log("Colisionamos con p3 el objeto " + this.name);
                break;
        }
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
    void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log(isdragging);
        
        if (collision.gameObject.tag == "p1")
        {
                
                lastQuestion = 0;
                lastQuestionSprite = collision.gameObject;
        }
        if (collision.gameObject.tag == "p2")
        {
                lastQuestion = 1;
                lastQuestionSprite = collision.gameObject;
               // GameObject text = lastQuestionSprite.transform.GetChild(0).gameObject;
        
        }
        if (collision.gameObject.tag == "p3")
        {

            lastQuestion = 2;
            lastQuestionSprite = collision.gameObject;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       // Debug.Log("salio del obj");
    }


}
