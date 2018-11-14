using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class ObtenerMateria : MonoBehaviour {
    
    string consultaMateriaURL = "https://ihcmon.000webhostapp.com/consultas.php";

    public void GetM()
    {
        StartCoroutine(GetMateria());
    }

    IEnumerator GetMateria()
    {
        WWWForm form = new WWWForm();
        form.AddField("funcion", "materia_nivel");
        form.AddField("parametros", 1);

        WWW www = new WWW(consultaMateriaURL, form);

        yield return www;

        Debug.Log(www.text);

        Materia materia = new Materia();
        materia = JsonUtility.FromJson<Materia>(www.text);

        Debug.Log(materia.id_materia);


    }

}
