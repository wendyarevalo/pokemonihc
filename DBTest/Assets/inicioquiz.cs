using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class inicioquiz : MonoBehaviour {

    public Text pregunta;
    private string resp;
    string PreguntaURL = "https://ihcmon.000webhostapp.com/consultar_pregunta.php";
    string RespuestaURL = "https://ihcmon.000webhostapp.com/consultar_respuesta.php";
    // Use this for initialization
    IEnumerator Start () {
        // traer la pregunta de acuerdo al id de la materia
        pregunta.text = "cargando ...";
        //ConsultaPregunta(2, 1);
        //consultar la respuesta de esa pregunta
        WWWForm form = new WWWForm();
        form.AddField("idmat", 4);
        form.AddField("nquiz", 1);

        WWW www = new WWW(PreguntaURL, form);
      
        yield return www;
        pregunta.text = www.text;

        Debug.Log(www.text);
        //consultar la respuesta
        WWWForm form2 = new WWWForm();
        form2.AddField("pregunta", pregunta.text);

        WWW respuesta = new WWW(RespuestaURL, form2);

        yield return respuesta;
        Debug.Log(respuesta.text);
        resp = respuesta.text;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void btnf()
    {
        //verificar si resp es igual a la respuesta obtenida
        if (resp == "falso")
        {
            Debug.Log("se gano un pony");
        }
        else
        {
            Debug.Log("el pony escapo ... suerte para la proxima");
        }
    }
    public void btnv()
    {
        if (resp == "verdadero")
        {
            Debug.Log("se gano un pony");
        }
        else
        {
            Debug.Log("el pony escapo ... suerte para la proxima");
        }
    }
}
