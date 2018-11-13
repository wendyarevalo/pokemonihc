using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuizRL : MonoBehaviour {

    public Image pregunta1;
    public Image pregunta2;
    public Image pregunta3;
    public Image respuesta1;
    public Image respuesta2;
    public Image respuesta3;
    public PreguntaR mypregunta;
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
        pregunta1.GetComponentInChildren<Text>().text = mypregunta.pregunta1;
        pregunta2.GetComponentInChildren<Text>().text = mypregunta.pregunta2;
        pregunta3.GetComponentInChildren<Text>().text = mypregunta.pregunta3;
        respuesta1.GetComponentInChildren<Text>().text = mypregunta.respuesta1;
        respuesta2.GetComponentInChildren<Text>().text = mypregunta.respuesta2;
        respuesta3.GetComponentInChildren<Text>().text = mypregunta.respuesta3;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
