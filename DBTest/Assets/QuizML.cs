using System.Collections;
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
    private string UrlPregunta = "http://localhost/respaldo/consultas.php";
    // Use this for initialization
    IEnumerator Start()
    {
        // traer la pregunta y respuesta de acuerdo al id de la materia
        pregunta.text = "cargando ...";
        WWWForm form = new WWWForm();
        form.AddField("funcion", "consultar_preguntaMultiple");
        form.AddField("parametros", "{\"materia\": 3}");

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
            SceneManager.LoadScene("AtraparPony");
        }
        else
        {
            //no atrapo al pony
            Debug.Log(" NO ATRAPO PONY");
            mensaje.text = " ¡¡ RESPUESTA INCORRECTA, SUERTE PARA LA PROXIMA!!";
            SceneManager.LoadScene("AtraparPony");
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
}
