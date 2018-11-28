using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ArrastraPregunta : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public static GameObject itemBeingDragged;
    Vector3 startPosition;
    Transform startParent;
    public TMP_Text total;
    public TMP_Text intentos;


    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
    }

    

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

   

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        
        if (transform.parent != startParent)
        {
            transform.position = startPosition;
        }

        
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "r1" && this.gameObject.tag == "p1")
        {
           
            Debug.Log("Choco con la respuesta 1");
            ApplicationModel.aciertos++;
            Debug.Log(""+ ApplicationModel.aciertos);
            total.text = ApplicationModel.aciertos.ToString();
        }
        else if (other.gameObject.tag == "r2" && this.gameObject.tag == "p2")
        {
           
            Debug.Log("Choco con la respuesta 2");
            ApplicationModel.aciertos++;
            Debug.Log("" + ApplicationModel.aciertos);
            total.text = ApplicationModel.aciertos.ToString();
        }
        else if (other.gameObject.tag == "r3" && this.gameObject.tag == "p3")
        {
           
            Debug.Log("Choco con la respuesta 3");
            ApplicationModel.aciertos++;
            Debug.Log("" + ApplicationModel.aciertos);
            total.text = ApplicationModel.aciertos.ToString();
        }
        
        
    }


    public void OnTriggerExit(Collider other)
    {
        itemBeingDragged.GetComponent<BoxCollider>().enabled = false;
        other.enabled = false;
        ApplicationModel.intentos--;
        intentos.text = ApplicationModel.intentos.ToString();
    }





}