﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VFScript : MonoBehaviour {
    public Text pregunta;
    public Text mensaje;
    private string resp;
    public Pregunta mypregunta;
    private string UrlPregunta= "http://ihcmon.000webhostapp.com/consultas.php";
    // Use this for initialization
    IEnumerator Start()
    {
        // traer la pregunta y respuesta de acuerdo al id de la materia
        pregunta.text = "cargando ...";
        WWWForm form = new WWWForm();
<<<<<<< HEAD
        form.AddField("funcion", "consultar_preguntaVF");
        form.AddField("parametros", "{\"materia\":"+ ApplicationModel.QuizEntrenar+"}");
=======
        if (ApplicationModel.entrenar)
        {
            form.AddField("funcion", "consultar_preguntaVF");
            form.AddField("parametros", "{\"materia\":" + ApplicationModel.QuizEntrenar+ "}");
        }
        else
        {
            form.AddField("funcion", "consultar_preguntaVF");
            form.AddField("parametros", "{\"materia\":" + ApplicationModel.ponyId + "}");
        }
>>>>>>> 97fe044b4a0209039b187721d8ca3690a2b30b37

        WWW www = new WWW(UrlPregunta, form);
        yield return www;
        string json = www.text;
        Debug.Log(www.text);
        pregunta.text = json;
        JsonUtility.FromJsonOverwrite(json, mypregunta);
        pregunta.text = mypregunta.preguntas;
        Debug.Log(" json " + json);
        Debug.Log("" + mypregunta.respuesta);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void btnf()
    {
        //verificar si resp es igual a la respuesta obtenida
        if (mypregunta.respuesta == "falso")
        {
            Debug.Log("se gano un pony");
            mensaje.text = " ¡¡ RESPUESTA CORRECTA !!";
            if (ApplicationModel.entrenar)
            {
                ApplicationModel.entrenar = false;
                SceneManager.LoadScene("GameScene");
            }
            else
            {
                AddMateria();
            }
        }
        else
        {
            Debug.Log("el pony escapo ... suerte para la proxima");
            mensaje.text = " ¡¡ RESPUESTA INCORRECTA, SUERTE PARA LA PROXIMA!!";
            SceneManager.LoadScene("GameScene");
        }
    }
    public void btnv()
    {
        if (mypregunta.respuesta == "verdadero")
        {
            Debug.Log("se gano un pony");
            mensaje.text = " ¡¡ RESPUESTA CORRECTA !!";
            if (ApplicationModel.entrenar)
            {
                ApplicationModel.entrenar = false;
                SceneManager.LoadScene("GameScene");
            }
            else
            {
                AddMateria();
            }
           
        }
        else
        {
            Debug.Log("el pony escapo ... suerte para la proxima");
            mensaje.text = " ¡¡ RESPUESTA INCORRECTA, SUERTE PARA LA PROXIMA!!";

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
<<<<<<< HEAD
        form.AddField("parametros", "{\"id_materia\": "+ApplicationModel.QuizEntrenar+",\"id_usuario\": "+no_control+"}");
=======
        form.AddField("parametros", "{\"id_materia\": "+ApplicationModel.ponyId+",\"id_usuario\": "+no_control+"}");
>>>>>>> 97fe044b4a0209039b187721d8ca3690a2b30b37

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
