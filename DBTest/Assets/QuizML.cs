﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizML : MonoBehaviour {

    public Toggle respuesta1;
    public Toggle respuesta2;
    public Toggle respuesta3;
    public Text pregunta;
    public Button btn_enviar;
    private Text Buy;
    private int respondida;
    private string resp;
    public Text mensaje;
    public PreguntaM mypregunta;
    private string UrlPregunta = "http://ihcmon.000webhostapp.com/consultas.php";
    // Use this for initialization
    IEnumerator Start()
    {
        // traer la pregunta y respuesta de acuerdo al id de la materia
        pregunta.text = "cargando ...";
        WWWForm form = new WWWForm();
<<<<<<< HEAD
        form.AddField("funcion", "consultar_preguntaMultiple");
        form.AddField("parametros", "{\"materia\":"+ ApplicationModel.QuizEntrenar+"}");
=======
        if (ApplicationModel.entrenar)
        {
            form.AddField("funcion", "consultar_preguntaMultiple");
            form.AddField("parametros", "{\"materia\":" + ApplicationModel.QuizEntrenar + "}");

        }
        else
        {
            form.AddField("funcion", "consultar_preguntaMultiple");
            form.AddField("parametros", "{\"materia\":" + ApplicationModel.ponyId + "}");
>>>>>>> 97fe044b4a0209039b187721d8ca3690a2b30b37

        }
        WWW www = new WWW(UrlPregunta, form);
        yield return www;
        string json = www.text;
        pregunta.text = json;
        mypregunta = new PreguntaM();
        JsonUtility.FromJsonOverwrite(json, mypregunta);
        pregunta.text = mypregunta.pregunta;
        Debug.Log(" json " + json);
        Debug.Log("" + mypregunta.respuesta1);
        respuesta1.GetComponentInChildren<Text>().text = mypregunta.respuesta1;
        respuesta2.GetComponentInChildren<Text>().text = mypregunta.respuesta2;
        respuesta3.GetComponentInChildren<Text>().text = mypregunta.respuesta3;


    }


    // Update is called once per frame
    void Update () {
		
	}
    public void enviar()
    {
        if (mypregunta.correcta == respondida)
        {
            //atrapo al pony
            Debug.Log(" ATRAPO PONY");
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
            //no atrapo al pony
            Debug.Log(" NO ATRAPO PONY");
            mensaje.text = " ¡¡ RESPUESTA INCORRECTA, SUERTE PARA LA PROXIMA!!";
            SceneManager.LoadScene("GameScene");
        }
    }
    public void op1()
    {
        respondida = 1;
    }
    public void op2()
    {
        respondida = 2;
    }
    public void op3()
    {
        respondida = 3;
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
        form.AddField("parametros", "{\"id_materia\": " + ApplicationModel.QuizEntrenar + ",\"id_usuario\": " + no_control + "}");
=======
        form.AddField("parametros", "{\"id_materia\": " + ApplicationModel.ponyId + ",\"id_usuario\": " + no_control + "}");
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
