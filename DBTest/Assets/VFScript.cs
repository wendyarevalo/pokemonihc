using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VFScript : MonoBehaviour {
    public Text pregunta;
    public Text mensaje;
    private string resp;
    public Pregunta mypregunta;
    private string UrlPregunta= "http://localhost/respaldo/consultas.php";
    // Use this for initialization
    IEnumerator Start()
    {
        // traer la pregunta y respuesta de acuerdo al id de la materia
        pregunta.text = "cargando ...";
        WWWForm form = new WWWForm();
        form.AddField("funcion", "consultar_preguntaVF");
        form.AddField("parametros", "{\"materia\": 2}");

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
            SceneManager.LoadScene("AtraparPony");
        }
        else
        {
            Debug.Log("el pony escapo ... suerte para la proxima");
            mensaje.text = " ¡¡ RESPUESTA INCORRECTA, SUERTE PARA LA PROXIMA!!";
            SceneManager.LoadScene("AtraparPony");
        }
    }
    public void btnv()
    {
        if (mypregunta.respuesta == "verdadero")
        {
            Debug.Log("se gano un pony");
            mensaje.text = " ¡¡ RESPUESTA CORRECTA !!";
            SceneManager.LoadScene("AtraparPony");
        }
        else
        {
            Debug.Log("el pony escapo ... suerte para la proxima");
            mensaje.text = " ¡¡ RESPUESTA INCORRECTA, SUERTE PARA LA PROXIMA!!";
            SceneManager.LoadScene("AtraparPony");

        }
    }
}
