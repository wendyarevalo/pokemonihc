using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class QuizRL : MonoBehaviour {

    public PreguntaR mypregunta;
    public TMP_Text r1;
    public TMP_Text r2;
    public TMP_Text r3;
    public TMP_Text p1;
    public TMP_Text p2;
    public TMP_Text p3;
    


    // Use this for initialization
    IEnumerator Start()
    {
        WWWForm form = new WWWForm();
        form.AddField("funcion", "consultar_preguntaCol");
        form.AddField("parametros", "{\"materia\":"+4+"}");

        WWW www = new WWW(ApplicationModel.URLConsultas, form);
        yield return www;
        string json = www.text;
        mypregunta = new PreguntaR();
        JsonUtility.FromJsonOverwrite(json, mypregunta);
        Debug.Log(" json " + json);
        Debug.Log("" + mypregunta.respuesta1);
        List<string> respuestas = new List<string>();
        List<string> preguntas = new List<string>();
        p1.text = mypregunta.pregunta1;
        p2.text = mypregunta.pregunta2;
        p3.text = mypregunta.pregunta3;
        r1.text = mypregunta.respuesta1;
        r2.text = mypregunta.respuesta2;
        r3.text = mypregunta.respuesta3;
        
    }

    // Update is called once per frame
    void Update() {

    }



}


