using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Accessibility;

public class MostrarAsistente : MonoBehaviour {

    public RectTransform asistente;
    float x = -3.05f;
    float y = 0f;
    float z = 0f;
    bool mostarAasistente = ApplicationModel.mostarAasistente;
    public Image ImagePony;
    public Text text;
    public Toggle Toggle;
    public Canvas Canvas;
    public Canvas menu;

    void Start() {
        mostarAasistente = ApplicationModel.mostarAasistente;
        Toggle_Changed(mostarAasistente);
        
	}
    

    public void Toggle_Changed(bool newValue)
    {
        ApplicationModel.mostarAasistente = newValue;
        if (newValue == true)
        {
            //showAsistente();
            Canvas.enabled = true;
            ImagePony.enabled = true;
            text.enabled = true;
            Toggle.enabled = true;
            menu.enabled = false;
            ApplicationModel.mostarAasistente = true;
            Debug.Log("Se deberia mostar la imagen");
        }
        else
        {
            Canvas.enabled = false;
            ImagePony.enabled = false;
            text.enabled = false;
            Toggle.enabled = false;
            menu.enabled = true;
            ApplicationModel.mostarAasistente = false;
            Debug.Log("NO SE DEBERIA MOSTAR LA IMAGEN");
        }
    }

    public void showAsistente()
    {
        Instantiate(asistente, new Vector3(x, y, z), Quaternion.identity);
        Debug.Log("se mostro el asistente");
    }




}


