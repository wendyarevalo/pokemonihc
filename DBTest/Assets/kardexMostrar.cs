using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class kardexMostrar : MonoBehaviour {

    public UnityEngine.UI.Image[] Images;
    public UnityEngine.UI.Text[] Texts;


    string MateriaUrl = "http://ihcmon.000webhostapp.com/consultas.php?funcion=materias_usuario&parametros=14121153";

    // Use this for initialization
    void Start () {

        Images[0].enabled = false;
        Texts[2].enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
