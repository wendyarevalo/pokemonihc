using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

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
        if (ApplicationModel.intentos == 0)
        {
            if (ApplicationModel.intentos == 3)
            {
                //agregar a la BD
                if (ApplicationModel.entrenar)
                {
                    ApplicationModel.entrenar = false;
                    SceneManager.LoadScene("GameScene");
                }
                else
                {
                    //mandar a bd add mat
                    AddMateria();

                }
            }
            else
            {
                SceneManager.LoadScene("GameScene");
            }
        }
        else
        {
            SceneManager.LoadScene("GameScene");
        }
    }


    public void AddMateria()
    {
        StartCoroutine(AddMateriaBD(PlayerPrefs.GetString("no_control")));
    }

    IEnumerator AddMateriaBD(string no_control)
    {
        Debug.Log("hilo ejecutandose " + no_control);
        WWWForm form = new WWWForm();
        form.AddField("funcion", "addmat_alumno");
        form.AddField("parametros", "{\"id_materia\": " + ApplicationModel.ponyId + ",\"id_usuario\": " + no_control + "}");

        WWW www = new WWW(ApplicationModel.URLInsert, form);

        yield return www;
        Debug.Log("recibo de url");
        Debug.Log(" respuesta " + www.text);

        if (www.text.Equals("insert correcto"))
        {
            Debug.Log("SE INSERTO CORRECTAMENTE EN LA BD");
            SceneManager.LoadScene("GameScene");
        }


    }


}