using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuizRL : MonoBehaviour {

   // public Image pregunta1;
   // public Image pregunta2;
    /*public Image pregunta3;
    public Image respuesta1;
    public Image respuesta2;
    public Image respuesta3;*/
    //public Sprite p1;
    //public Sprite p2;
    public PreguntaR mypregunta;
    public TextMesh t1;
    private string UrlPregunta = "http://ihcmon.000webhostapp.com/consultas.php";
    // Use this for initialization
    IEnumerator Start()
    {
        WWWForm form = new WWWForm();
        form.AddField("funcion", "consultar_preguntaCol");
        form.AddField("parametros", "{\"materia\": 3}");

        WWW www = new WWW(UrlPregunta, form);
        yield return www;
        string json = www.text;
        mypregunta = new PreguntaR();
        JsonUtility.FromJsonOverwrite(json, mypregunta);
        Debug.Log(" json " + json);
        Debug.Log("" + mypregunta.respuesta1);
        /*  pregunta1.GetComponentInChildren<Text>().text = mypregunta.pregunta1;
          pregunta2.GetComponentInChildren<Text>().text = mypregunta.pregunta2;
          pregunta3.GetComponentInChildren<Text>().text = mypregunta.pregunta3;
          respuesta1.GetComponentInChildren<Text>().text = mypregunta.respuesta1;
          respuesta2.GetComponentInChildren<Text>().text = mypregunta.respuesta2;
          respuesta3.GetComponentInChildren<Text>().text = mypregunta.respuesta3;*/
        t1.text = mypregunta.pregunta1;
    }

    // Update is called once per frame
    void Update() {

    }
}
