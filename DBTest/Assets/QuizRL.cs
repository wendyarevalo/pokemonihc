using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuizRL : MonoBehaviour {

    public PreguntaR mypregunta;
    public TextMesh r1;
    public TextMesh r2;
    public TextMesh r3;
    public TextMesh p1;
    public TextMesh p2;
    public TextMesh p3;
    // Use this for initialization
    IEnumerator Start()
    {
        WWWForm form = new WWWForm();
        form.AddField("funcion", "consultar_preguntaCol");
        form.AddField("parametros", "{\"materia\":"+ ApplicationModel.ponyActual+ "}");

        WWW www = new WWW(ApplicationModel.URLConsultas, form);
        yield return www;
        string json = www.text;
        mypregunta = new PreguntaR();
        JsonUtility.FromJsonOverwrite(json, mypregunta);
        Debug.Log(" json " + json);
        Debug.Log("" + mypregunta.respuesta1);
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
